using CoreBase.Help;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static CoreBase.Winform.ComponentExtensions;

namespace NovelDownload
{
    internal static class Program
    {
        /// <summary>
        /// 全局唯一識別碼
        /// </summary>
        static string appGuid = "{5C301E67-AD3C-46E4-8F54-2119737B5F2D}";
        #region EXIT CODE
        /// <summary>
        /// 作業已成功完成(0)
        /// </summary>
        public const int ERROR_SUCCESS = 0x0;
        /// <summary>
        /// 存取遭到拒絕(5)
        /// </summary>
        public const int ERROR_ACCESS_DENIED = 0x5;
        /// <summary>
        /// 沒有足夠的記憶體資源可用來處理此命令(8)
        /// </summary>
        public const int ERROR_NOT_ENOUGHT_MEMORY = 0x8;
        /// <summary>
        /// 沒有足夠的儲存體可完成此作業(14)
        /// </summary>
        public const int ERROR_OUTOFMEMORY = 0xE;
        #endregion
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex m = new Mutex(false, "Global\\" + appGuid))
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }

        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                Show(exception);
            }
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception exception = e.Exception;
            Show(exception);
        }
        private static void Show(Exception exception)
        {
            var VersionNumber = $"{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion}";
            var GetSourceInnerException = exception.GetInnerException();
            var errorDetailStr = GetSourceInnerException.ErrorMessage + Environment.NewLine + Environment.NewLine +
                                 GetSourceInnerException.Stacktrace;
            try
            {
                RadMessageBox.Show(errorDetailStr, $"錯誤訊息[{VersionNumber}]", MessageBoxButtons.OK,
                    RadMessageIcon.Error, MessageBoxDefaultButton.Button1, errorDetailStr);
            }
            finally
            {
                MessageBox.Show(errorDetailStr, $"錯誤訊息[{VersionNumber}]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region 檢查是否重複執行 20201204-佳靜
        /// <summary>
        /// 檢查是否重複執行 20201204-佳靜
        /// </summary>
        /// <returns></returns>
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            // Loop through the running processes in with the same name   
            foreach (Process process in processes)
            {
                // Ignore the current process  
                if (process.Id != current.Id)
                {
                    // Make sure that the process is running from the exe file.   
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //Return the other process instance.  
                        return process;
                    }
                }
            }
            // No other instance was found, return null. 
            return null;
        }
        public static void HandleRunningInstance(Process instance)
        {
            // Make sure the window is not minimized or maximized 
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            // Set the real intance to foreground window
            SetForegroundWindow(instance.MainWindowHandle);
        }
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        //1:normal
        //2:minimized
        //3:maximized
        private const int WS_SHOWNORMAL = 3;
        #endregion

    }
}