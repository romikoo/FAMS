using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using Helpers;
using XNA;

namespace Fams
{
    static class Program
    {
        [STAThread]
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
           

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //User user = new User("რომან ქურდაძე");
                //Game game = new Game(user);

                /*FormMenu m = new FormMenu();
                Application.Run(m);*/

                frmMonitoring f = new frmMonitoring();
                Application.Run(f);



            /*
                frmLogin login = new frmLogin();


            
            User user = new User("რომან ქურდაძე");
            login.user = user;

                Application.Run(login);


                if (login.user != null)
                {
                    Splash sp = new Splash();
                    sp.Show();
                    System.Windows.Forms.Application.DoEvents();

                    using (Game game = new Game(login.user))
                    {
                        game.Run();
                    }
                }
           
            */



        }
        
       }
}

