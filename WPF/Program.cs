namespace WPF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using Xilium.CefGlue;

    internal static class Program
    {
        [STAThread]
        private static int Main(string[] args)
        {
            try
            {
                CefRuntime.Load();
            }
            catch (DllNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return 1;
            }
            catch (CefRuntimeException ex)
            {
                MessageBox.Show(ex.Message);
                return 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 3;
            }

            var mainArgs = new CefMainArgs(args);
            var app1 = new DemoApp();

            var exitCode = CefRuntime.ExecuteProcess(mainArgs, app1);
            if (exitCode != -1)
                return exitCode;

            var settings = new CefSettings
            {
                // BrowserSubprocessPath = @"D:\fddima\Projects\Xilium\Xilium.CefGlue\CefGlue.Demo\bin\Release\Xilium.CefGlue.Demo.exe",
                SingleProcess = false,
                MultiThreadedMessageLoop = true,
                LogSeverity = CefLogSeverity.Disable,
                LogFile = "CefGlue.log",
            };

            CefRuntime.Initialize(mainArgs, settings, app1);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            if (!settings.MultiThreadedMessageLoop)
            {
                //WApplication.Idle += (sender, e) => { CefRuntime.DoMessageLoopWork(); };
            }

            var app = new App();
            app.InitializeComponent();
            app.Run();

            CefRuntime.Shutdown();
            return 0;
        }
    }
}
