using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace LearnLifeWin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
		{
			// Add the event handler for handling UI thread exceptions to the event. http://msdn.microsoft.com/en-us/library/ms157905.aspx
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			// Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			// Add the event handler for handling non-UI thread exceptions to the event. 
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			if (!string.IsNullOrEmpty(LearnLifeWin.Properties.Settings.Default.Language))
			{
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(LearnLifeWin.Properties.Settings.Default.Language);
			}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			if (LearnLifeWin.Properties.Settings.Default.ShowTutorial)
			{
				Application.Run(new TutorialMain());
			}
			else
			{
				Application.Run(new MainForm());
			}
        }

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			MessageBox.Show(e.ToString(), "Thread Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			MessageBox.Show(e.ToString(), "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
    }
}
