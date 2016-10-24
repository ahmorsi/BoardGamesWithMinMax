using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BoardGameProject
{
    static class Program
    {
        public static Game Controller = new Game();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //static public Game GameControler = new Game();
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Splash());
        }
    }
}
