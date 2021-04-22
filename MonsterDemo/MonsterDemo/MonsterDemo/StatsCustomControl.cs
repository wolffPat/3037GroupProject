#region

using System;
using System.Windows.Forms;

#endregion

namespace MonsterDemo
{
    public partial class StatsCustomControl : UserControl
    {
        private static double TimeT { get; set; }

        public StatsCustomControl()
        {
            InitializeComponent();
        }
        
        
        public static void LvlLabel2Update(string lvl)
        {
            LvlLbl2.Text = $"Level: {lvl}";
        }

        public static void HealthLblUpdate(int health, int tHealth)
        {
            if (tHealth < 0) { tHealth = 0; }
            if (health < 0) { health = 0; }
            if (AttackLbl == null) return;
            
            
            HealthLbl.Text = $"{health} / {tHealth}";
        }

        public static void XpLblUpdate(string xp, string Txp)
        {
            XpLbl.Text = $"{xp} / {Txp}";
        }

        public static void AttackLblUpdate(string attack)
        {
            if (AttackLbl == null) return;
            AttackLbl.Text = attack;
        }

        public static void TimePlayedLblUpdate(double time)
        {
            TimeT += time; //*10 because this is from tick 1 10th of a second, shouldn't be here but rushing...
            if (TimeT < 1)
            {
                TimePlayedLbl.Text = $"Time Open: Less Than A Min";

            }
            if (TimeT % 1 != 0) return;
            
            TimePlayedLbl.Text = $"Time Open: {TimeT} Min";
        }

        public static void BattleWonLblUpdate(int won)
        {
            XpLbl.Text = $"Battles Won: {won}";
        }

        public static void FriendshipLblUpdate(int friendship)
        {
            if (friendship >= 5)
            {
                if (friendship < 10)
                    RealationshipLbl.Text = "Acquaintance";
                else if (friendship <= 15)
                    RealationshipLbl.Text = "Friend";
                else if (friendship <= 30)
                    RealationshipLbl.Text = "Best Friend";
                else if (friendship <= 60) RealationshipLbl.Text = "Best Friends Forever";
            }
            else
                RealationshipLbl.Text = "Stranger";
        }


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