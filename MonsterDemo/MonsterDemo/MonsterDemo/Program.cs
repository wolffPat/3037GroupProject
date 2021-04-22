using System.Windows.Forms;

namespace MonsterDemo
{
    internal static class Program
    {
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}