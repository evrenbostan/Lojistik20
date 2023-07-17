using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace Lojistik20
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName(Assembly.GetEntryAssembly().GetName().Name).Count() > 1)
            {
                MessageBox.Show("Programınız Zaten Çalışmaktadır","UYARI", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AnaGiris());
            }
        }
    }
}
