using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace MonsterDemo
{
    public partial class MonsterSettings : Form
    {

        public MonsterSettings()
        {
            InitializeComponent();
            if (MainForm.Hardmode) HardCheckbox.CheckState = CheckState.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => MainForm.Hardmode = HardCheckbox.Checked;

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
            string path =Application.StartupPath + @"\Properties.json";

            File.Delete(path);
            Application.Restart();
            Environment.Exit(0);
        }
        

      
    }
}