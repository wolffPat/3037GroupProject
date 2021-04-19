using System.Drawing;
using System.Windows.Forms;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Timer = System.Windows.Forms.Timer;
using settings = MonsterDemo.Properties.Settings;

namespace MonsterDemo
{
    class Monster
    {
        public Monster()
        {
        }

        public static string Name { get; set; }
        public static int MonsterXp { get; set; }
        public static int MonsterLvl { get; set; }
        public static int MonsterHealth { get; set; }
        public static int MonsterTotalHealth { get; set; }
        public static int MonsterAttack { get; set; }
        public static int MonsterFriendShip { get; set; }
        public static string MonsterFacts { get; set; }


        public static void EveryTick(object sender, EventArgs e)
        {
            var points = Logger.LetterPoints;
            MonsterXp = points * 5;

            var newXpGate = Math.Round(Math.Pow(2, MonsterLvl--));
            if (points != newXpGate) return;
            MonsterLvl++;
            MainForm.SaveSettings();
        }
        
    }
}