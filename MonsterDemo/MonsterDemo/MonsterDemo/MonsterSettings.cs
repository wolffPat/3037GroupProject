using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MonsterDemo
{
    public partial class MonsterSettings : Form
    {
        public static bool HardMode { get; private set; }

        public MonsterSettings()
        {
            InitializeComponent();
            if (Properties.Settings.Default.HardMode)
            {
                HardCheckbox.CheckState = CheckState.Checked;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            HardMode = HardCheckbox.Checked;
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startupPath = Environment.CurrentDirectory;

            Process.Start("explorer.exe", startupPath);
        }
        
        private void DebugResetAll_Click(object sender, EventArgs e)
        {
            // I reset and put things to there original values, Multiple times because It was acting strange...
            //overkill...
            Logger.LetterPoints = 0;
            Properties.Settings.Default.Name = "Grayson";
            Properties.Settings.Default.Xp = 0;
            Properties.Settings.Default.Attack = 1;
            Properties.Settings.Default.MaxHealth = 5;
            Properties.Settings.Default.Health = 5;
            Properties.Settings.Default.Lvl = 0;
            Properties.Settings.Default.Freindship = 0;
            Properties.Settings.Default.HardMode = false; // Should update without these two but had an issue

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload(); //just in case..
            Properties.Settings.Default.Save();

            Logger.LetterPoints = 0;
            Monster.MonsterAttack = 1;
            Monster.MonsterHealth = 5;
            Monster.MonsterFriendShip= 0;
            Monster.MonsterMaxHealth = 5;
            Monster.MonsterLvl = 0;
            Monster.MonsterName = "Grayson";
            Monster.MonsterXp = 0;
            HardMode = false;

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload(); //just in case..
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Name = "Grayson";
            Properties.Settings.Default.Xp = 0;
            Properties.Settings.Default.Attack = 1;
            Properties.Settings.Default.MaxHealth = 5;
            Properties.Settings.Default.Health = 5;
            Properties.Settings.Default.Lvl = 0;
            Properties.Settings.Default.Freindship = 0;
            Properties.Settings.Default.HardMode = false;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload(); //just in case..
            Properties.Settings.Default.Save();
        }
        
        
        
        
    }
}