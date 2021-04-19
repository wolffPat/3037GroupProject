using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MonsterDemo
{
 
    public partial class MonsterSettings : Form
    {
        public static bool HardMode { get; private set; }

        public MonsterSettings()
        {
            InitializeComponent();
            if (Properties.Settings.Default.HardMode) { HardCheckbox.CheckState = CheckState.Checked; }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           HardMode = HardCheckbox.Checked;
        }
        
       
        private void DebugResetAll_Click(object sender, EventArgs e)
        {

            Logger.LetterPoints = 0;
            Properties.Settings.Default.Name = "Name";
            Properties.Settings.Default.Xp = 0;
            Properties.Settings.Default.Attack = 0;                            
            Properties.Settings.Default.TotalHealth = 10;                  
            Properties.Settings.Default.CurrentHealth = 10;                     
            Properties.Settings.Default.Level = 0;                                
            Properties.Settings.Default.Freindship =0;           
            Properties.Settings.Default.HardMode = false;
            Properties.Settings.Default.Save();                                                    


        }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string startupPath = Environment.CurrentDirectory;

            Process.Start("explorer.exe", startupPath);

        }
    }
}