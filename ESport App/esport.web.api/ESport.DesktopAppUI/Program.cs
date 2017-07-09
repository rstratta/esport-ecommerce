using ESport.DesktopAppUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESport.Data.Service;
using ESport.Data.Entities;
using ESport.Data.Commons;
using ESport.Logger.Manager;
using ESport.Data.Repository;
using ESport.Logger.Repository;

namespace ESport.DesktopAppUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login loginWindows = GetLoginWindow();
            Application.Run(loginWindows);
        }

        private static Login GetLoginWindow()
        {
            return new Login(new ServiceFactory());
        }
    }
}