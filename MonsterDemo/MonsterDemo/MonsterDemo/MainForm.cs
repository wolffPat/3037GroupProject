#region
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Nucs.JsonSettings;
using Timer = System.Windows.Forms.Timer;

#endregion

namespace MonsterDemo
{
    public partial class MainForm : Form
    {
        private static SettingsBag _mProperty = JsonSettings.Load<SettingsBag>("Properties.json").EnableAutosave();
        private dynamic _prop= _mProperty.AsDynamic();
        
        
        //private bool _timerstop=false;//not used currently 
        
        private static int _currentMonster = 1;
        public MainForm()
        {
            //6 monster limit currently 
            var monsters = new object[6];

            //first run will be null
            if (_prop.mCount == null) { _prop.mCount = 1; }
            for (int i = 1; i <= Convert.ToInt32(_prop.mCount); i++)
            {
                //the constructor gets the stats from property file on creation
                monsters[i]= new Monster(_prop, i);
            }
            
            //Starts thread that logs & makes it a child thread(HIGHPriority)
            ThreadStart childRef = Logging;
            var childThread = new Thread(childRef) {IsBackground = false};
            childThread.Start(); childThread.Priority = ThreadPriority.Highest;
            
            //initialize main form & shows the monsterTab first
            InitializeComponent();
            mainCustomControl.BringToFront();
            SidePanel.Height =  monsterTab.Height; 
            SidePanel.Top = monsterTab.Top;
            
            //update all labels and starts waiting for leveling monster
            LabelTimer((Monster) monsters[_currentMonster]);
            LevelTimer((Monster) monsters[_currentMonster]);
            
        }
        
        private static Monster _monsterPrint;
        public static bool Hardmode { get; set; }
        private int _counter;
        
        private void LabelUpdate(object sender, EventArgs eventArgs)
        {
            _counter++;
            //mainCustomForm gets level updates from file
            mainCustomControl.LvlLabel1Update(_monsterPrint.MonsterLvl.ToString());
            
            //statsCustomForm gets level updates from file
            statsCustomControl.LvlLabel2Update(_monsterPrint.MonsterLvl.ToString());
            statsCustomControl.AttackLblUpdate(_monsterPrint.MonsterAttack.ToString());
            statsCustomControl.XpLblUpdate(_monsterPrint.MonsterXp.ToString(),_monsterPrint.MonsterMaxXp.ToString());
            statsCustomControl.FriendshipLblUpdate(_monsterPrint.MonsterFriendShip);
            statsCustomControl.HealthLblUpdate(_monsterPrint.MonsterHealth,_monsterPrint.MonsterMaxHealth);
            statsCustomControl.TimePlayedLblUpdate(_counter);
            statsCustomControl.NameChange(_monsterPrint.MonsterName);
            //* future
            //statsCustomControl.BattleWonLblUpdate();
            //statsCustomControl.TimePlayedLblUpdate();
        }
        
        //calls in a new thread in background 
        //for counting real words typed
        private static void Logging()
        {
            //starts checking for words and adding them the chars to LetterPoints
            Logger.Start();
        }
        private void LabelTimer(Monster monster) 
        {
            //if (_timerstop) return;
            Timer myTimer = new Timer {Interval = (1000)}; // Every second
            myTimer.Tick += LabelUpdate;
         
            mainCustomControl.SetMName(monster.MonsterName);
            _monsterPrint = monster;
            //if (_timerstop) return;
            myTimer.Start();
            
        }
        private void LevelTimer(Monster monster) 
        {
           //if (_timerstop) return;
            Timer myTimer = new Timer {Interval = (100)}; // Every 1-10th of a second
            myTimer.Tick += monster.LevelUpdate;
            SaveMonster(monster);
           //if (_timerstop) return;
            myTimer.Start();
        }
        private void SaveMonster(Monster monster)
        {
            if (_prop == null) return; //safety
            _prop.mLvl = monster.MonsterLvl;
            _prop.mMaxHealth = monster.MonsterMaxHealth;
            _prop.mHealth = monster.MonsterHealth;
            _prop.mAttack = monster.MonsterAttack;
            _prop.mFriendhsip = monster.MonsterFriendShip;
            _prop.mXp = monster.MonsterXp;
            _prop.mMaxXp = monster.MonsterMaxXp;
            _prop.mNum = monster.MonsterNumber;
        }


        // Mouse events are for moving the window without top bar  
        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) _lastPoint = new Point(e.X, e.Y);
        }
        private Point _lastPoint;// location of mouse
        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Left += e.X - _lastPoint.X;
            Top += e.Y - _lastPoint.Y;
        }
        
        //all tabs will call this
        private void MakeFront(Control sidetab, UserControl customControl)
        {
            //sets tab to have light on side
            SidePanel.Height = sidetab.Height; SidePanel.Top = sidetab.Top;
            //Opens corresponding panel
            customControl.Show();
            customControl.BringToFront();
        }
        
        //the rest are tabs/buttons mostly calling MakeFront
        private void CloseButton_Click(object sender, EventArgs e)
        {
            _monsterPrint.MonsterName = mainCustomControl.MonsterName;
            _prop.mName = _monsterPrint.MonsterName;

            SaveMonster(_monsterPrint);
            Environment.Exit(Environment.ExitCode); //this will close all threads
            //Close(); same as above but all threads
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settings = new MonsterSettings();
            settings.Show();
        }
        private void SizeToggleButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void StatsButtonClick(object sender, EventArgs e)
        {
            MakeFront(statTab, statsCustomControl);
        }

        //private void FightTab_Click(object sender, EventArgs e) => MakeFront(fightTab2,fightCustomControl);
        private void HomeButtonClick(object sender, EventArgs e)
        {
            MakeFront(monsterTab, mainCustomControl);
        }
    }
}