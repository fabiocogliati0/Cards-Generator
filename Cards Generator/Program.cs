﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Cards_Generator
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
            Application.Run(new CardsGeneratorApplicationContext());
        }
    }

    class CardsGeneratorApplicationContext : ApplicationContext
    {

        public CardsGeneratorApplicationContext()
        {
            _currentFSM = FSM.CreateFSM(Paths.CardsGeneratorFSMPath);
            _currentFSM.Start();
        }


        private FSM _currentFSM;
    }
}
