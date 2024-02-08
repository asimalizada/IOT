using IOTSystem.WinUI;
using System;
using System.Windows.Forms;

namespace IOTSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IncomeOutcomeTracking());
        }
    }
}
