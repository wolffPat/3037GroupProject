#region

using System;
using System.Drawing;
using System.Management.Instrumentation;
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
        public static bool HardMode { get; set; }

        public static Monster _monsterPrint;
        //%private bool _timerstop=false;%//not used currently 

        public MainForm()
        {
            //6 monster limit currently 
            var monsters = new object[6];    
            
            
            
            
            
                                                                                                                                                     // ReSharper disable once HeuristicUnreachableCode
            //first run will be null                                                                                                                                                                 // ReSharper disable once HeuristicUnreachableCode
            if (_mProperty["HardMode"] == null) _mProperty["HardMode"] = false.ToString();
            HardMode = Convert.ToBoolean(_mProperty["HardMode"]);
                                                                                                                                                // ReSharper disable once HeuristicUnreachableCode
            //first run will be null                                                                                                  // ReSharper disable once HeuristicUnreachableCode
            if (_mProperty["mCount"] == null) _mProperty["mCount"] = 1;



            for (int i = 1; i <= Convert.ToInt32(_mProperty["mCount"]); i++)
            {
                //the constructor gets the stats from property file on creation
                monsters[i] = new Monster(_mProperty, i);

            }
            //update all labels and starts leveling monsters
            PerformPerSecond((Monster) monsters[_currentMonster]);
            
            
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

                
                
          

            
        } 
        
        private static int _counter;
        private void LabelUpdate(object sender, EventArgs eventArgs)
        {
            
            //mainCustomForm gets level updates from file
            mainCustomControl.LvlLabel1Update(_monsterPrint.MonsterLvl.ToString());
            mainCustomControl.SetTextBoxAndName(_monsterPrint);

            //statsCustomForm gets level updates from file
            statsCustomControl.LvlLabel2Update(_monsterPrint.MonsterLvl.ToString());
            statsCustomControl.AttackLblUpdate(_monsterPrint.MonsterAttack.ToString());
            statsCustomControl.XpLblUpdate(_monsterPrint.MonsterXp.ToString(), _monsterPrint.MonsterMaxXp.ToString());
            statsCustomControl.FriendshipLblUpdate(_monsterPrint.MonsterFriendShip);
            statsCustomControl.HealthLblUpdate(_monsterPrint.MonsterHealth, _monsterPrint.MonsterMaxHealth);
            statsCustomControl.NameUpdate(_monsterPrint.MonsterName);
            _counter++; statsCustomControl.TimePlayedLblUpdate(_counter);


            //*statsCustomControl.BattleWonLblUpdate();
            //*statsCustomControl.TimePlayedLblUpdate();
        }

        //calls in a new thread in background, for counting real words typed
        private static void Logging() => Logger.Start();

        private static bool firstLoad;
        private void PerformPerSecond(Monster monster)
        {
            var myTimer = new Timer {Interval = (1000/2)}; // Every half second
            myTimer.Tick += monster.LevelUpdate;
            myTimer.Tick += LabelUpdate;
            myTimer.Start();
        }

       public static void SaveMonster(Monster monster)
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
            _mProperty["HardMode"] = HardMode.ToString();
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
            SaveMonster(_monsterPrint);
            
            Environment.Exit(Environment.ExitCode);
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