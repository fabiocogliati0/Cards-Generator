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
    public partial class CreditForm : Form
    {
        public FSMState ControllerState;
        private Random rndColor = new Random();

        public CreditForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ControllerState.FireAction("Back", "");
        }

        private void lblManuele_MouseEnter(object sender, EventArgs e)
        {
            lblManuele.ForeColor = System.Drawing.Color.FromArgb(rndColor.Next(1,255), rndColor.Next(1, 255), rndColor.Next(1, 255));
            lblFabio.ForeColor = System.Drawing.Color.FromArgb(rndColor.Next(1, 255), rndColor.Next(1, 255), rndColor.Next(1, 255));
        }
    }
}
