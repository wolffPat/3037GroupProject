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
        private bool _checkFirstrun = true;
        public static int LogPath = Properties.Settings.Default.LogPoints;


        public MainForm()
        {
            GetSettings();
            ThreadStart childRef = Logging;
            var childThread = new Thread(childRef) {IsBackground = true};
            childThread.Start();
            InitializeComponent();
            SidePanel.Height = monsterTab.Height;
            SidePanel.Top = monsterTab.Top;
            mainCustomControl.BringToFront();
        }

        private static void GetSettings()
        {
            Monster.Name = Properties.Settings.Default.Name;
            Monster.MonsterXp = Properties.Settings.Default.Xp;
            Monster.MonsterAttack = Properties.Settings.Default.Attack;
            Monster.MonsterTotalHealth = Properties.Settings.Default.TotalHealth;
            Monster.MonsterHealth = Properties.Settings.Default.CurrentHealth;
            Monster.MonsterLvl = Properties.Settings.Default.Level;
            Monster.MonsterFriendShip = Properties.Settings.Default.Freindship;
            ;
        }

        public static void SaveSettings()
        {
            Properties.Settings.Default.Name = Monster.Name;
            Properties.Settings.Default.Xp = Monster.MonsterXp;
            Properties.Settings.Default.Attack = Monster.MonsterAttack;
            Properties.Settings.Default.TotalHealth = Monster.MonsterTotalHealth;
            Properties.Settings.Default.CurrentHealth = Monster.MonsterHealth;
            Properties.Settings.Default.Level = Monster.MonsterLvl;
            Properties.Settings.Default.Freindship = Monster.MonsterFriendShip;
            Properties.Settings.Default.HardMode = MonsterSettings.HardMode;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

           

        }

        //calls in a new thread in background 
        //for counting real words typed
        private static void Logging()
        {
            //starts checking for words and adding them the chars to LetterPoints
            Logger.Start(LogPath);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var MyTimer = new Timer {Interval = (5000)}; // Every 5 seconds
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
            Properties.Settings.Default.Save();

            MessageBox.Show(Properties.Settings.Default.Xp.ToString());
            MessageBox.Show(Properties.Settings.Default.Attack.ToString());
            MessageBox.Show(Properties.Settings.Default.TotalHealth.ToString());
            MessageBox.Show(Properties.Settings.Default.CurrentHealth.ToString());
            MessageBox.Show(Properties.Settings.Default.Level.ToString());
            MessageBox.Show(Properties.Settings.Default.Freindship.ToString());
            MessageBox.Show(Properties.Settings.Default.HardMode.ToString());
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