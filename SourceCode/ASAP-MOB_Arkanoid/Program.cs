using System;
using System.Windows.Forms;

namespace ASAP_MOB_Arkanoid
{
    static class Program
    {
        public static string usuario = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());;
        }
    }
}