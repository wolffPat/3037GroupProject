using System.Windows.Forms;
using System;

using System.Media;
using settings = MonsterDemo.Properties.Settings;

namespace MonsterDemo
{
    class Monster
    {
        public Monster()
        {
        }

        public static string MonsterName { get; set; }
        public static int MonsterXp { get; set; }
        public static int MonsterLvl { get; set; }
        public static int MonsterHealth { get; set; }
        public static int MonsterMaxHealth { get; set; }
        public static int MonsterAttack { get; set; }
        public static int MonsterFriendShip { get; set; }
        public static string MonsterFacts { get; set; }

        static double newXpGate;
        
        
        
        
        public static void EveryTick(object sender, EventArgs e)
        {
           // StatsCustomControl.TimePlayedLblUpdate(1);
            MonsterXp = Logger.LetterPoints;
            
            switch (MonsterLvl)
            {
                case 0:
                    newXpGate = 2;
                    break;
                case 1:
                    newXpGate = 10;
                    break;
                default:
                {
                    if (MonsterLvl <= 6)
                        newXpGate = Math.Round(Math.Pow(2, MonsterLvl - 1)) * 5;
                    else if (MonsterLvl <= 10)
                        newXpGate = Math.Round(Math.Pow(2, MonsterLvl - 1) * 2);   
                    else
                        newXpGate = Math.Round(Math.Pow(2, MonsterLvl - 1) + 2);
                    break;
                }
            }
            StatsCustomControl.XpLblUpdate(MonsterXp.ToString(),newXpGate.ToString());

            
            if (MonsterXp < newXpGate) return; 
            
            MonsterLvl++;//LEVEL UP!
            MainCustomControl.LvlLabel1Update(MonsterLvl.ToString());
            StatsCustomControl.LvlLabel2Update(MonsterLvl.ToString());

            MonsterHealth += 5;
            MonsterMaxHealth += 5;
            StatsCustomControl.HealthLblUpdate(MonsterHealth,MonsterMaxHealth);

            if (MonsterLvl % 5 == 0)
            {
                MonsterAttack += 5;
                StatsCustomControl.AttackLblUpdate(MonsterAttack.ToString());
            }

            using (var soundPlayer = new SoundPlayer(Application.StartupPath + @"\LevelUp.wav")) {
                soundPlayer.Play(); 
            }
            
            Logger.LetterPoints = 0; MonsterXp = 0; //reset points and xp
            MainForm.SaveSettings();
   
         

            
            
        }


    }
}