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
    public partial class LocalizationForm : Form
    {

        public FSMState ControllerState;

        private string _selectLanguageTextKey;
        private string _OkButtonLanguageTextKey;


        public LocalizationForm()
        {
            InitializeComponent();

            _selectLanguageTextKey = lblLanguageSelection.Text;
            _OkButtonLanguageTextKey = btnContinue.Text;
            RefreshContent();
        }

        public void RefreshContent()
        {
            lblLanguageSelection.Text = UIUtils.ResolveTextKey(_selectLanguageTextKey);
            btnContinue.Text = UIUtils.ResolveTextKey(_OkButtonLanguageTextKey);
        }


        private void btnContinue_Click(object sender, EventArgs e)
        {
            ControllerState.FireAction("Proceed", "");
        }

        private void rdbEnglish_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEnglish.Checked)
            {
                ControllerState.FireAction("ChangeLanguage", "English");
            }
        }

        private void rdbItalian_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbItalian.Checked)
            {
                ControllerState.FireAction("ChangeLanguage", "Italian");
            }
        }
    }
}
