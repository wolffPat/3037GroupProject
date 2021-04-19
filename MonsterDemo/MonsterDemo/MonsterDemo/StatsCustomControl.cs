#region

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace MonsterDemo
{
    public partial class StatsCustomControl : UserControl
    {
        private readonly sbyte RED = 2;
        private readonly sbyte YELLOW = 3;
        public StatsCustomControl()
        {
            InitializeComponent();
            //this changes the progressbars to different colors
            ModifyProgressBarColor.SetState(progressBar1, RED);
            ModifyProgressBarColor.SetState(progressBar2, YELLOW);

        }

        private void MonsterLabel_Click(object sender, EventArgs e)
        {
            NameBox.Visible = true;
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }




}
