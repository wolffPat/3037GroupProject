using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

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
        public static string word = "";
        public static int wCount = 0;
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {


            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {

                System.IO.StreamReader file = new System.IO.StreamReader(notepadPath);

                int vkCode = Marshal.ReadInt32(lParam);
                var keyName = Enum.GetName(typeof(Keys), vkCode);
                string currentXp = file.ReadLine();
                file.Close();
                if (keyName == "Space")
                {

                    if (File.ReadAllText(Application.StartupPath+ @"\words.txt").ToUpper().Contains(word))
                    {
                        wCount++;   
                    }

                    word = "";
                }
                else if(keyName=="Back")
                {
                    if(word!="")
                    {
                        word = word.Substring(0, word.Length - 1);
                    }
                    
                }
                else
                {
                    
                    word = word + keyName.ToString();
                }

                using (StreamWriter sw = new StreamWriter(notepadPath))
                { 
                    sw.Write(wCount);
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}
