using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Full_Project.Use_Controller;

namespace DVLD_Full_Project
{
    internal static class Program
    {
        public static bool IsRestart { set; get; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Test());
            Application.Run(new Main());

            //#region//              Main Run For Me
            //do
            //{
            //    IsRestart = false;
            //    frmmLogin Login = new frmmLogin();
            //    Application.Run(Login);
            //    if (Login.DialogResult == DialogResult.OK)
            //    {
            //        Application.Run(new Main());
            //    }
            //}
            //while (IsRestart);
            //#endregion
        }
    }
}
