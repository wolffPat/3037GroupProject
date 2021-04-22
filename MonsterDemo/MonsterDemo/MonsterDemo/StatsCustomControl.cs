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
       
        private static int _timeT;
        public StatsCustomControl()
        {
            InitializeComponent();
        }
        
  
        
        public static void LvlLabel2Update(string lvl)
        {
            LvlLbl2.Text = $"Level: {lvl}";
        }

        public static void HealthLblUpdate(int Health,int tHealth)
        {
            if (AttackLbl == null) return;
            HealthLbl.Text = $"{Health} / {tHealth}";
        }  
       
        public static void XpLblUpdate(string xp,string Txp)
        {
            XpLbl.Text = $"{xp} / {Txp}";
        }  
        public static void AttackLblUpdate(string attack)
        {
            if (AttackLbl == null) return;
            AttackLbl.Text = attack;
        }  
        public static void TimePlayedLblUpdate(int time)
        {
            _timeT += (time/10)/6; //*10 because this is from tick 1 10th of a second, shouldn't be here but rushing...
            TimePlayedLbl.Text = $"Time Played: {_timeT} Min";
        }  
        public static void BattleWonLblUpdate(int won)
        {
            XpLbl.Text = $"Battles Won: {won}";
        } 
        public static void FriendshipLblUpdate(int Friendship)
        {
            if (Friendship <= 5) RealationshipLbl.Text = "Stranger";
            
            switch (Friendship)
            {
                case 5:
                    RealationshipLbl.Text = "Acquaintance";
                    break;
                case 10:
                    RealationshipLbl.Text = "Friend";
                    break;
                case 30:
                    RealationshipLbl.Text = "Best Friend";
                    break;
                case 60:
                    RealationshipLbl.Text = "Best Friends Forever";
                    break;
            }
        }


        /*private void NameText2_TextChanged(object sender, EventArgs e)
        {
            NameText2.Text = Monster.MonsterName;
            Monster.MonsterName = NameText2.Text;
        }*/

        private void StatsCustomControl_Load(object sender, EventArgs e)
        {
            NameText2.Text = Monster.MonsterName;
            FriendshipLblUpdate(Monster.MonsterFriendShip);
            HealthLblUpdate(Monster.MonsterHealth, Monster.MonsterMaxHealth);
            LvlLabel2Update(Monster.MonsterLvl.ToString());
            AttackLblUpdate(Monster.MonsterAttack.ToString());
        }
    }




}
