using System.Windows.Forms;
using System;
using System.Media;
using Nucs.JsonSettings;

namespace MonsterDemo
{
    public class Monster
    {
        public Monster(SettingsBag prop, int count)
        {
            //will say it is never used but it is. This is to dynamically make/name each settings for each new monster
                                                                           // ReSharper disable once UnusedVariable
            var mMaxHealth = "m" + count + "MaxHealth";
            var mHealth = $"m{count}Health";
            var mName = "m" + count + "Name";
            var mAttack = "m" + count + "Attack";
            var mFriendship = "m" + count + "Friendship";
            var mXp = "m" + count + "Xp";
            var mMaxXp = "m" + count + "MaxXp";
            var mLvl = "m" + count + "Lvl";


            if (prop[mName] == null)
            {
                // its first time making this monster so give them defaults
                prop[mName] = "Name";
                prop[mHealth] = 5;
                prop[mMaxHealth] = 5;
                prop[mAttack] = 0;
                prop[mFriendship] = 0;
                prop[mXp] = 0;
                prop[mMaxXp] = 1;
                prop[mLvl] = 1;
                prop["mNum"] = count;
            }

            //not first time making this monster so grab all its settings
            MonsterName = Convert.ToString(prop[mName]);
            MonsterMaxHealth = Convert.ToInt32(prop[mMaxHealth]);
            MonsterHealth = Convert.ToInt32(prop[mHealth]);
            MonsterAttack = Convert.ToInt32(prop[mAttack]);
            MonsterFriendShip = Convert.ToInt32(prop[mFriendship]);
            MonsterXp = Convert.ToInt32( prop[mXp]);
            MonsterMaxXp = Convert.ToInt32( prop[mMaxXp]);
            MonsterLvl = Convert.ToInt32( prop[mLvl]);
            MonsterNumber = Convert.ToInt32(prop["mNum"]);
        }
        public void LevelUpdate(object sender, EventArgs e)
        {
            //statsCustomControl.TimePlayedLblUpdate(1);
            MonsterXp = Logger.LetterPoints;

            switch (MonsterLvl)
            {
                case 0:
                    MonsterMaxXp = 2;
                    break;
                case 1:
                    MonsterMaxXp = 10;
                    break;
                default:
                {
                    if (MonsterLvl <= 6)
                        MonsterMaxXp = (int) (Math.Round(Math.Pow(2, MonsterLvl - 1)) * 5);
                    else if (MonsterLvl <= 10)
                        MonsterMaxXp = (int) Math.Round(Math.Pow(2, MonsterLvl - 1) * 2);
                    else
                        MonsterMaxXp = (int) Math.Round(Math.Pow(2, MonsterLvl - 1) + 2);
                    break;
                }
            }

            if (MonsterXp < MonsterMaxXp) return;
            //else

            MonsterLvl++; //LEVEL UP!
            MonsterHealth += 5;
            MonsterMaxHealth += 5;


            //every 5 levels +5 attack damage
            if (MonsterLvl % 5 == 0)
            {
                MonsterAttack += 5;
            }

            using (var soundPlayer = new SoundPlayer(Application.StartupPath + @"\LevelUp.wav"))
            {
                soundPlayer.Play();
            }


            Logger.LetterPoints = 0;
        }
        public string MonsterName { get; set; }
        public int MonsterXp { get; private set; }
        public int MonsterMaxXp { get; private set; }
        public int MonsterLvl { get; private set; }
        public int MonsterHealth { get; private set; }
        public int MonsterMaxHealth { get; private set; }
        public int MonsterAttack { get; private set; }
        public int MonsterFriendShip { get; set; } //currently not implemented

        public int MonsterNumber { get; set; } //currently not implemented

        //public static string MonsterFacts { get; set; }
    }
}