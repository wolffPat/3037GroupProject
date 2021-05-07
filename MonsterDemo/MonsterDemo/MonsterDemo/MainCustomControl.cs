#region
using System;
using System.Windows.Forms;
#endregion

namespace MonsterDemo
{
    public partial class MainCustomControl : UserControl
    {
        //int mfriendship;
        public string MonsterName;
        public MainCustomControl()
        {
            InitializeComponent();
        }

        public void LvlLabel1Update(string lvl)
        {
            LvlLabel1.Text = lvl;
        }

        private void Changed(object sender, EventArgs e)
        {
            MonsterName = NameBox.Text;
        }

        public void SetMName(string mn)
        {
            MonsterName = mn;
            NameBox.Text = MonsterName;
        }
    }
}