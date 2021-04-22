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
        
  
        
        public static void LvlLabel2Update(string lvl)
        {
            LvlLbl2.Text = $"Level: {lvl}";
        }

        public static void HealthLblUpdate(string Health,string tHealth)
        {
            HealthLbl.Text = $"{Health} / {tHealth}";
        }  
       
        public static void XpLblUpdate(string xp,string Txp)
        {
            XpLbl.Text = $"{xp} / {Txp}";
        }  
        public static void TimePlayedLblUpdate(int time)
        {
            XpLbl.Text = $"Time Played: {time}";
        }  
        public static void BattleWonLblUpdate(int won)
        {
            XpLbl.Text = $"Battles Won: {won}";
        }


        private void NameText2_TextChanged(object sender, EventArgs e)
        {
            NameText2.Text = Monster.MonsterName;

        }
    }




}
