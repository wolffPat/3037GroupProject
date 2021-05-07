#region

using System.Windows.Forms;

#endregion

namespace MonsterDemo
{
    public partial class StatsCustomControl : UserControl
    {
        public StatsCustomControl()
        {
            InitializeComponent();
        }
        
        public void LvlLabel2Update(string lvl) => LvlLbl2.Text = @"Level: " + lvl;
        public void XpLblUpdate(string xp, string txp) => XpLbl.Text = $@"{xp} / {txp}";
        public void NameChange(string monsterName) => NameText2.Text = monsterName;
        public void TimePlayedLblUpdate(double seconds) => TimePlayedLbl.Text = $@"Time Open: {seconds} seconds";
        public void AttackLblUpdate(string attack)
        {
            if (AttackLbl == null) return;
            AttackLbl.Text = attack;
        }
        public void HealthLblUpdate(int health, int tHealth)
        {
            if (tHealth < 0) tHealth = 0;
            if (health < 0) health = 0;
            if (AttackLbl == null) return;
            
            HealthLbl.Text = $@"{health} / {tHealth}";
        }
        public void FriendshipLblUpdate(int friendship)
        {
            if (friendship >= 5)
            {
                if (friendship < 10)
                    RealationshipLbl.Text = @"Acquaintance";
                else if (friendship <= 15)
                    RealationshipLbl.Text = @"Friend";
                else if (friendship <= 30)
                    RealationshipLbl.Text = @"Best Friend";
                else if (friendship <= 60) RealationshipLbl.Text = @"Best Friends Forever";
            }
            else
                RealationshipLbl.Text = @"Stranger";
        }
        public void StatsCustomControlUpdate(Monster monster)
        {
            FriendshipLblUpdate(monster.MonsterFriendShip);
            HealthLblUpdate(monster.MonsterHealth, monster.MonsterMaxHealth);
            LvlLabel2Update(monster.MonsterLvl.ToString());
            AttackLblUpdate(monster.MonsterAttack.ToString());
        }
        public void BattleWonLblUpdate(int won) => XpLbl.Text = $@"Battles Won: {won}";

    }
}