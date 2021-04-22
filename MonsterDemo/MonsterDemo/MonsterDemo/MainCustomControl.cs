#region

using System;
using System.Windows.Forms;

#endregion

namespace MonsterDemo
{
    public partial class MainCustomControl : UserControl
    {
        public MainCustomControl()
        {
            InitializeComponent();
        }
        
        public static void LvlLabel1Update(string lvl)
        {
            LvlLabel1.Text = lvl;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Freindship = Monster.MonsterFriendShip;// Should update without these two but had an issue
            Monster.MonsterFriendShip = Properties.Settings.Default.Freindship;

            Monster.MonsterFriendShip += 1;
            StatsCustomControl.FriendshipLblUpdate(Monster.MonsterFriendShip);
        }


        
    }
}