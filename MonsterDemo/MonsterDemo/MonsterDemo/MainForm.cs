#region

using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

#endregion

namespace MonsterDemo
{
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            GetSettings();
            ThreadStart childRef = Logging;
            var childThread = new Thread(childRef) {IsBackground = false };
            childThread.Start();
            childThread.Priority = ThreadPriority.Highest;
            InitializeComponent();
            SidePanel.Height = monsterTab.Height;
            SidePanel.Top = monsterTab.Top;
            MainCustomControl.LvlLabel1Update(Properties.Settings.Default.Lvl.ToString());
            mainCustomControl.BringToFront();
        }

        private static void GetSettings()
        {
            Monster.MonsterName = Properties.Settings.Default.Name;
            Monster.MonsterXp = Properties.Settings.Default.Xp;
            Monster.MonsterAttack = Properties.Settings.Default.Attack;
            Monster.MonsterMaxHealth = Properties.Settings.Default.MaxHealth;
            Monster.MonsterHealth = Properties.Settings.Default.Health;
            Monster.MonsterLvl = Properties.Settings.Default.Lvl;
            Monster.MonsterFriendShip = Properties.Settings.Default.Freindship;
            StatsCustomControl.AttackLblUpdate(Monster.MonsterAttack.ToString());
            StatsCustomControl.HealthLblUpdate(Monster.MonsterHealth,Monster.MonsterMaxHealth);


        }

        public static void SaveSettings()
        {
            Properties.Settings.Default.Name = Monster.MonsterName;
            Properties.Settings.Default.Xp = Monster.MonsterXp;
            Properties.Settings.Default.Attack = Monster.MonsterAttack;
            Properties.Settings.Default.MaxHealth = Monster.MonsterMaxHealth;
            Properties.Settings.Default.Health = Monster.MonsterHealth;
            Properties.Settings.Default.Lvl = Monster.MonsterLvl;
            Properties.Settings.Default.Freindship = Monster.MonsterFriendShip;
            Properties.Settings.Default.HardMode = MonsterSettings.HardMode;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();//just in case... had issues
            Properties.Settings.Default.Save();
            

        }

        //calls in a new thread in background 
        //for counting real words typed
        private static void Logging()
        {
            //starts checking for words and adding them the chars to LetterPoints
            
                Logger.Start();

            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var MyTimer = new Timer {Interval = (100)}; // Every 1-10th of a second
            MyTimer.Tick += Monster.EveryTick;
            MyTimer.Start();
            
            
            
        }

        private void HomeButtonClick(object sender, EventArgs e)
        {
            SidePanel.Height = monsterTab.Height;
            SidePanel.Top = monsterTab.Top;
            mainCustomControl.Show();
            mainCustomControl.BringToFront();
        }

        private void StatsButtonClick(object sender, EventArgs e)
        {
            SidePanel.Height = statTab.Height;
            SidePanel.Top = statTab.Top;
            statsCustomControl.Show();
            statsCustomControl.BringToFront();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            Properties.Settings.Default.Save(); //just in case... had issues

          
            //MessageBox.Show(Properties.Settings.Default.MaxHealth.ToString());
           // MessageBox.Show(Properties.Settings.Default.Health.ToString());
            //MessageBox.Show(Properties.Settings.Default.Xp.ToString());
           // MessageBox.Show(Properties.Settings.Default.Lvl.ToString());
      
          
            Close();
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

        //Both mouse events are for moving the windows without the usual top bar  
        private void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) _lastPoint = new Point(e.X, e.Y);
        }

        // _lastPoint used as location of mouse
        private Point _lastPoint;

        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Left += e.X - _lastPoint.X;
            Top += e.Y - _lastPoint.Y;
        }

        private void fightTab_Click(object sender, EventArgs e)
        {
            SidePanel.Height = fightTab.Height;
            SidePanel.Top = fightTab.Top;
            fight.Show();
            fight.BringToFront();
        }
    }
}