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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();

            // Set language to italian #TODO make language selection form
            Globals.Language = Globals.eLanguage.italian;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {

            // Generate loading string
            string loadingText = Properties.Strings.Loading;
            for(var i = 0; i < _loadingStringPointsNumber; ++i)
            {
                loadingText += ".";
            }
            lblLoading.Text = loadingText;
            _loadingStringPointsNumber = (_loadingStringPointsNumber + 1) % _MaxLoadingStringPointsNumber;


        }


        public FSMState ControllerState; 


        private const int _MaxLoadingStringPointsNumber = 10;


        private int _loadingStringPointsNumber = 0;

        private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ControllerState != null)
            {
                ControllerState.FireAction("Close","");
            }
        }
    }
}
