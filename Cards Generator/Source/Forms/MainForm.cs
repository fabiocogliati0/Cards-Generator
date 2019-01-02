using System;
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
    public partial class MainForm : Form
    {

        public FSMState ControllerState;


        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerator_Click(object sender, EventArgs e)
        {
            ControllerState.FireAction("ToGenerator","");
        }

        private void btnMapGenerator_Click(object sender, EventArgs e)
        {
            ControllerState.FireAction("ToMapGenerator", "");

        }
    }
}
