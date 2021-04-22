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
        /*private readonly sbyte RED = 2;
        private readonly sbyte YELLOW = 3;*/
        public StatsCustomControl()
        {
            InitializeComponent();
            
            //this changes the progressbars to different colors
            /*ModifyProgressBarColor.SetState(progressBar1, RED);
            ModifyProgressBarColor.SetState(progressBar2, YELLOW);*/

        }

        private void MonsterLabel_Click(object sender, EventArgs e)
        {
            NameBox.Visible = true;
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            Monster.MonsterName = e.ToString();
        }


        public static void LvlLabel2Update(string lvl)
        {
            LvlLabel2.Text = lvl;
        }      
        public static void XpLabelUpdate(string xp)
        {
            LvlLabel2.Text = xp;
        } 
        public static void Xp4LvlLabelUpdate(string Txp)
        {
            LvlLabel2.Text = Txp;
        }


      

  

      
    }




}
