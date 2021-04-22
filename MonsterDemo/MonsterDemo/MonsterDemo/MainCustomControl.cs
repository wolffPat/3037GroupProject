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

        private void NameBox_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public static void LvlLabel1Update(string lvl)
        {
            LvlLabel1.Text = lvl;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Monster.MonsterFriendShip++;
            StatsCustomControl.FriendshipLblUpdate(Monster.MonsterFriendShip);

        }
    }
}