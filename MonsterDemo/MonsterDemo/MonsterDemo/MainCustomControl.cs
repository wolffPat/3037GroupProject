#region
using System;
using System.Windows.Forms;
#endregion

namespace MonsterDemo
{
    public partial class MainCustomControl : UserControl
    {
        private string _newChangedName;
        //int mfriendship;
        
        
        
        public MainCustomControl()
        {
            InitializeComponent();
        }

        public void LvlLabel1Update(string lvl) => LvlLabel1.Text = lvl;
        
        private void Changed(object sender, EventArgs e)
        {
            _newChangedName = StartNameBox.Text;
        }
        
        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            StartNameBox.ReadOnly = false;
        }


        public void SetTextBoxAndName(Monster monster)
        {
            //if text changed set name to text else just change the text to the current name
            if (_newChangedName != null)
                monster.MonsterName = _newChangedName;
            else
                StartNameBox.Text = monster.MonsterName;
        }
    }
}