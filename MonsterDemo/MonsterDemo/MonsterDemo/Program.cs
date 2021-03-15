using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MonsterDemo
{
    static class Program
    {
     //   [STAThread]
/*          public const int WM_NCLBUTTONDOWN = 0xA1;
            public const int HT_CAPTION = 0x2;
            public static IntPtr Handle { get; private set; }

            [DllImportAttribute("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, 
            int Msg, int wParam, int lParam);
            [DllImportAttribute("user32.dll")]
            public static extern bool ReleaseCapture();


        private static void MainForm_MouseDown(object sender, 
        System.Windows.Forms.MouseEventArgs e)
        {     
    if (e.Button == MouseButtons.Left)
    {
        ReleaseCapture();
        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
    }
        }*/


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }








    }
}
