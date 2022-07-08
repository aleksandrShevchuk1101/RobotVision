using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace CS_KEHRATEC
{
    static class ClassDLLImports
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }

        public static void PreventMonitorPowerdown()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }

        public static void AllowMonitorPowerdown()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }
        
        public static void PreventSleep()
        {
            // Prevent Idle-to-Sleep (monitor not affected) (see note above)
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
        }

        public static void KeepSystemAwake()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED);
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public enum MouseActionAdresses
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        public static void LeftClick(int x, int y)
        {
            // Simulation Mausclick Links
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseActionAdresses.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseActionAdresses.LEFTUP), 0, 0, 0, 0);
        }

        public static void RightClick(int x, int y)
        {
            // Simulation Mausclick Rechts
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseActionAdresses.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseActionAdresses.RIGHTUP), 0, 0, 0, 0);
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void LoadSoftkeyboard(bool bOnMode)
        {
            bool bFound = false;

            // Konstanten für ShowWindow
            //const int SW_SHOWNORMAL = 1;
            //const int SW_SHOWMINIMIZED = 2;
            //const int SW_SHOWMAXIMIZED = 3;

            if ((ClassDaten.structOptionData.iPeriferieTyp & (int)ClassDaten.PeriferieTyp.SoftKeyboard) > 0)
            {
                string sFileName = "SoftTastatur.exe";
                if (File.Exists(sFileName))
                {
                    Process[] localByName = Process.GetProcessesByName("SoftTastatur");
                    foreach (Process myProcess in localByName)
                    {
                        // Wenn der Process schon existiert, Process killen
                        if (!myProcess.HasExited)
                        {
                            myProcess.Kill();
                            bFound = false;
                        }

                        // Wenn der Process schon existiert, Fenster darstellen
                        //ShowWindow(myProcess.MainWindowHandle, SW_SHOWNORMAL);
                        //bFound = true;
                    }

                    if (!bFound)
                    {
                        if( bOnMode)
                            // Wenn die Tastatur aktiviert werden soll
                            Process.Start(sFileName);
                    }
                }
                else
                    MessageBox.Show("File " + sFileName + " not found");
            }
        }
    }

    public class MessageHelper
    {
        [DllImport("User32.dll")]
        private static extern int RegisterWindowMessage(string lpString);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
        //For use with WM_COPYDATA and COPYDATASTRUCT
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
        //For use with WM_COPYDATA and COPYDATASTRUCT
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(int hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(int hWnd);
        public const int WM_USER = 0x400;
        public const int WM_RESULT = 0x401;
        public const int WM_COPYDATA = 0x4A;

        public const string WINDOW_NAME = "VisionControl";

        //Used for WM_COPYDATA for string messages
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        public bool bringAppToFront(int hWnd)
        {
            return SetForegroundWindow(hWnd);
        }
        public int PostWindowsMessage(int Msg, int wParam, int lParam)
        {
            int result = 0;
            int hWnd = getWindowId(null, WINDOW_NAME);

            if (hWnd > 0)
            {
                result = PostMessage(hWnd, Msg, wParam, lParam);
            }
            return result;
        }
        public int SendWindowsStringMessage(int hWnd, int wParam, string msg)
        {
            int result = 0;
            if (hWnd > 0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(msg);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = msg;
                cds.cbData = len + 1;
                result = SendMessage(hWnd, WM_COPYDATA, wParam, ref cds);
            }
            return result;
        }
        public int SendWindowsStringMessage(int wParam, string msg)
        {
            int result = 0;
            int hWnd = getWindowId(null, WINDOW_NAME);
            if (hWnd > 0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(msg);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = msg;
                cds.cbData = len + 1;
                result = SendMessage(hWnd, WM_COPYDATA, wParam, ref cds);
            }
            return result;
        }
        public int SendWindowsMessage(int hWnd, int Msg, int wParam, int lParam)
        {
            int result = 0;
            if (hWnd > 0)
            {
                result = SendMessage(hWnd, Msg, wParam, lParam);
            }
            return result;
        }
        public int SendWindowsMessage(int Msg, int wParam, int lParam)
        {
            int result = 0;
            int hWnd = getWindowId(null, WINDOW_NAME);

            if (hWnd > 0)
            {
                result = SendMessage(hWnd, Msg, wParam, lParam);
            }
            return result;
        }
        public int getWindowId(string className, string windowName)
        {
            return FindWindow(className, windowName);
        }
    }

}
