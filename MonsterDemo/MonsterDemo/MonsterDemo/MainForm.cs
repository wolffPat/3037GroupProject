#region

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

#endregion

namespace MonsterDemo
{
    public partial class MainForm : Form
    {
        string notepadPath = Application.StartupPath + @"\testMonster.txt";

        public MainForm()
        {
            ThreadStart childref = startLogging;
            Thread childThread = new Thread(childref);
            childThread.IsBackground = true;
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
            Timer MyTimer = new Timer();
            MyTimer.Interval = (45 * 60 * 1000); // 45 mins
            MyTimer.Tick += MyTimer_Tick;
            MyTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            //  string allText=  File.ReadAllText(notepadPath);
            //int xpPrimative = allText.Length;

            //this.Close();
        }

        public void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) _lastPoint = new Point(e.X, e.Y);
        }

        private Point _lastPoint;


        private void MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - _lastPoint.X;
                Top += e.Y - _lastPoint.Y;
            }
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sizeToggleButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
        }
    }
}