using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    static class Program
    {
        public static MainForm mainForm;
        public static ExtendForm extendForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            extendForm = new ExtendForm();
            Application.Run(mainForm);
            //Application.Run(new ExtendForm());
        }
    }
}
