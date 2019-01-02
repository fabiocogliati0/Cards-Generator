﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards_Generator
{
    public partial class GenerateMapForm : Form
    {

        public FSMState ControllerState;


        public GenerateMapForm()
        {
            InitializeComponent();
        }

        public void SetMap(int[,] tiles)
        {
            MapVisualizer.SetMap(tiles);
        }
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            ControllerState.FireAction("Back", "");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ControllerState.FireAction("Generate", "");
        }
    }

    
}
