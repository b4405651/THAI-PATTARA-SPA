using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Management;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

namespace SPA_MANAGEMENT_SYSTEM
{
    static class Program
    {
        public static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static Process currentProcess;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (Process.GetProcessesByName("SPA MANAGEMENT SYSTEM").Length <= 1)
                {
                    AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                    Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                    Application.ApplicationExit += (ss, ee) =>
                    {
                        if (GF.is_logged_in)
                        {
                            DB.logout();
                        }
                    };
                    
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    if (!File.Exists(GF.path)) File.Create(GF.path);
                    else File.WriteAllText(GF.path, String.Empty);

                    //Application.Run(new login());
                    Application.Run(new main_page());
                    // Check if user is NOT admin
                    if (!IsRunningAsAdministrator())
                    {
                        // Setting up start info of the new process of the same application
                        ProcessStartInfo processStartInfo = new ProcessStartInfo(Assembly.GetEntryAssembly().CodeBase);

                        // Using operating shell and setting the ProcessStartInfo.Verb to “runas” will let it run as admin
                        processStartInfo.UseShellExecute = true;
                        processStartInfo.Verb = "runas";

                        // Start the application as new process
                        currentProcess = Process.Start(processStartInfo);

                        // Shut down the current (old) process
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }

            catch (Win32Exception e)
            {
                GF.doDebug("\r\n\r\n APPLICATION EXIT WITH CODE : " + e.ErrorCode);
                GF.doDebug("\r\n\r\n" + e.Message);
                GF.doDebug("\r\n\r\n" + e.StackTrace);

                GF.doDebug("\r\n\r\nFile : " + new StackTrace(e, true).GetFrame(0).GetFileName());
                GF.doDebug("\r\n\r\nLine : " + new StackTrace(e, true).GetFrame(0).GetFileLineNumber());

                if (currentProcess != null) currentProcess.Kill();
                System.Environment.Exit(0);
            }
        }

        public static bool IsRunningAsAdministrator()
        {
            // Get current Windows user
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

            // Get current Windows user principal
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);

            // Return TRUE if user is in role "Administrator"
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                GF.closeLoading();
                Exception ex = (Exception)e.ExceptionObject;
                GF.doDebug("********** FATAL UNHANDLED EXCEPTION ERROR : " + Environment.MachineName + " **********");
                GF.doDebug(" [" + ex.TargetSite.ToString() + "]");
                GF.doDebug(ex.Message);
                GF.doDebug("\r\n\r\n" + ex.StackTrace);

                GF.doDebug("\r\n\r\nFile : " + new StackTrace(ex, true).GetFrame(0).GetFileName());
                GF.doDebug("\r\n\r\nLine : " + new StackTrace(ex, true).GetFrame(0).GetFileLineNumber());
                
                GF.submitErrorLog();
                waitHandle.WaitOne();
                /*MessageBox.Show("Whoops! Please contact the developers with the following"
                      + " information:\n\n" + ex.Message + ex.StackTrace,
                      "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);*/
            }
            finally
            {
                if (currentProcess != null) currentProcess.Kill();
                System.Environment.Exit(0);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                GF.closeLoading();
                Exception ex = (Exception)e.Exception;
                GF.doDebug("********** THREAD FATAL ERROR : " + Environment.MachineName + " **********");
                GF.doDebug(" [" + ex.TargetSite.ToString() + "]");
                GF.doDebug(ex.Message);
                GF.doDebug("\r\n\r\n" + ex.StackTrace);

                GF.doDebug("\r\n\r\nFile : " + new StackTrace(ex, true).GetFrame(0).GetFileName());
                GF.doDebug("\r\n\r\nLine : " + new StackTrace(ex, true).GetFrame(0).GetFileLineNumber());

                GF.submitErrorLog();
                waitHandle.WaitOne();
            }
            finally
            {
                if(currentProcess != null) currentProcess.Kill();
                System.Environment.Exit(0);
            }
        }
    }
}
