using AGVDispatcher.Util;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGVDispatcher
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            string MName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
            string PName = System.IO.Path.GetFileNameWithoutExtension(MName);
            System.Diagnostics.Process[] myProcess = System.Diagnostics.Process.GetProcessesByName(PName);
            if (myProcess.Length > 1)
            {
                MessageBox.Show("你不能多次启动本程序，请先关闭运行中的实例！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string logfile = "./Roaming/Error.log";
            string logbkup = "./Roaming/Error.log.old";
            if (File.Exists(logfile) && (new FileInfo(logfile)).Length > 10*1024*1024)
            {
                if (File.Exists(logbkup))
                    File.Delete(logbkup);
                File.Move(logfile, logbkup);
            }

            var lsn = new TextWriterTraceListener(logfile);
            Trace.Listeners.Add(lsn);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Helpers.LogInfo("========程序启动！========");
#if DEBUG
            Application.Run(new UI.Form1());
#else
            Application.Run(new UI.fm_main());
#endif
            Helpers.LogInfo("========程序结束！========");
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Helpers.LogException(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Helpers.LogException(e.ExceptionObject as Exception ?? new Exception("未处理且无法识别为Exception的错误发生！"));
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Helpers.LogException(e.Exception);
        }
    }
}