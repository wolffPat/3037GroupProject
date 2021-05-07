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
        private static int _currentMonster = 1;
        //%private bool _timerstop=false;%//not used currently 
        
        public MainForm()
        {
            //6 monster limit currently 
            var monsters = new object[6];

            //first run will be null
            // ReSharper disable once HeuristicUnreachableCode
            if (_mProperty["mCount"] == null) _mProperty["mCount"] = 1;

            for (int i = 1; i <= Convert.ToInt32(_mProperty["mCount"]); i++)
            {
                //the constructor gets the stats from property file on creation
                monsters[i] = new Monster(_mProperty, i);
            }

            //Starts thread that logs & makes it a child thread(HIGHPriority)
            ThreadStart childRef = Logging;
            var childThread = new Thread(childRef) {IsBackground = false};
            childThread.Start();
            childThread.Priority = ThreadPriority.Highest;

            //initialize main form & shows the monsterTab first
            InitializeComponent();
            mainCustomControl.BringToFront();
            SidePanel.Height = monsterTab.Height;
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
            statsCustomControl.XpLblUpdate(_monsterPrint.MonsterXp.ToString(), _monsterPrint.MonsterMaxXp.ToString());
            statsCustomControl.FriendshipLblUpdate(_monsterPrint.MonsterFriendShip);
            statsCustomControl.HealthLblUpdate(_monsterPrint.MonsterHealth, _monsterPrint.MonsterMaxHealth);
            statsCustomControl.TimePlayedLblUpdate(_counter);
            statsCustomControl.NameChange(_monsterPrint.MonsterName);

            //*statsCustomControl.BattleWonLblUpdate();
            //*statsCustomControl.TimePlayedLblUpdate();
        }

        //calls in a new thread in background, for counting real words typed
        private static void Logging() => Logger.Start();
        
        private void LabelTimer(Monster monster)
        {
            //if (_timerstop) return; //later?
            var myTimer = new Timer {Interval = (1000)}; // Every second
            myTimer.Tick += LabelUpdate;

            mainCustomControl.SetMName(monster.MonsterName);
            _monsterPrint = monster;
            //if (_timerstop) return;
            myTimer.Start();
        }

        private void LevelTimer(Monster monster)
        {
                                             //if (_timerstop) return; //later?
            var myTimer = new Timer {Interval = (100)}; // Every 1-10th of a second
            myTimer.Tick += monster.LevelUpdate;
            //if (_timerstop) return;
            myTimer.Start();
        }

        private void SaveMonster(Monster monster)
        {
            var count= monster.MonsterNumber;
            
            var mMaxHealth = $"m{count}MaxHealth";
            var mHealth = $"m{count}Health";
            var mName = $"m{count}Name";
            var mAttack = $"m{count}Attack";
            var mFriendship = $"m{count}Friendship";
            var mXp = $"m{count}Xp";
            var mMaxXp = $"m{count}MaxXp";
            var mLvl = $"m{count}Lvl";
            var mNumber = $"m{count}Number";
            
            
            if (_mProperty == null) return; //safety
            _mProperty[mLvl] = monster.MonsterLvl;
            _mProperty[mMaxHealth]= monster.MonsterMaxHealth;
            _mProperty[mHealth] = monster.MonsterHealth;
            _mProperty[mAttack] = monster.MonsterAttack;
            _mProperty[mFriendship] = monster.MonsterFriendShip;
            _mProperty[mXp] = monster.MonsterXp;
            _mProperty[mMaxXp] = monster.MonsterMaxXp;
            _mProperty[mNumber] = monster.MonsterNumber;
            _mProperty[mName] = monster.MonsterName;
        }


        // Mouse events are for moving the window without top bar  
        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _lastPoint = new Point(e.X, e.Y);
        }

        private Point _lastPoint; // location of mouse

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Left += e.X - _lastPoint.X;
            Top += e.Y - _lastPoint.Y;
        }

        //all tabs will call this
        private void MakeFront(Control sidetab, UserControl customControl)
        {
            //sets tab to have special clicked color slab thing on side of button
            SidePanel.Height = sidetab.Height;
            SidePanel.Top = sidetab.Top;
            
            //Opens corresponding panel
            customControl.Show();
            customControl.BringToFront();
        }

        //the rest are tabs/buttons mostly calling MakeFront
        private void CloseButton_Click(object sender, EventArgs e)
        {
            _monsterPrint.MonsterName = mainCustomControl.MonsterName;
            _mProperty["mName"] = _monsterPrint.MonsterName;

            SaveMonster(_monsterPrint);
            Environment.Exit(Environment.ExitCode); //this will close all threads
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settings = new MonsterSettings();
            settings.Show();
        }
        private void SizeToggleButton_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void StatsButtonClick(object sender, EventArgs e) => MakeFront(statTab, statsCustomControl);
        private void FightTab_Click(object sender, EventArgs e) => MakeFront(fightTab,fightCustomControl);
        private void HomeButtonClick(object sender, EventArgs e) => MakeFront(monsterTab, mainCustomControl);
    }
}