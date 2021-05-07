#region

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace MonsterDemo //name it the same as your project name
{
    internal static class Logger
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100; //keyDown
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookId = IntPtr.Zero;
        public static int LetterPoints { get; set; }
        private static string _word = "";


        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        public static void Start()
        {
            _hookId = SetHook(_proc);
            Application.Run();
            UnhookWindowsHookEx(_hookId);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0 || wParam != (IntPtr) WM_KEYDOWN) return CallNextHookEx(_hookId, nCode, wParam, lParam);
            var vkCode = Marshal.ReadInt32(lParam);

            //gets the key value- the character or keyboard button names-Space,Alt etc.
            var keyName = Enum.GetName(typeof(Keys), value: vkCode);


            switch (keyName.ToUpper())
            {
                //words only recognized on these button presses  
                case "SPACE":
                case "ENTER":
                case "TAB":
                case ".":
                case ",":
                case " ":
                {
                    //Searches Entire dictionary for typed word
                    if (File.ReadAllText(Application.StartupPath + @"\words.txt").ToUpper().Contains(_word.ToUpper()))
                    {
                        //points will equal the amount of letters in the word 
                        LetterPoints += _word.Length;
                    }

                    //Make word empty again 
                    _word = "";
                    break;
                }


                //backspace works like a backspace, gets rid of previous stuff
                case "BACK":
                {
                    //not blank
                    if (_word != "")
                    {
                        //gets rid of previous char
                        _word = _word.Substring(0, _word.Length - 1);

                        //hard-mode penalty
                        if (MainForm.Hardmode)
                        {
                            LetterPoints -= 5; //-5 points by default...
                        }
                    }

                    break;
                }
                case "ALT":
                case "CTRL":
                case "WIN":
                case "SHIFT":
                case "CAPS":
                case "ESCAPE":
                {
                    break;
                }
                
                default:
                {
                    //Creates the word letter by letter
                    _word += keyName;
                    break;
                }
            }

            LetterPoints = LetterPoints;

            //keep going

            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }
    }
}