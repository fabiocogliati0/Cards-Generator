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
    public partial class GenerateRandomCardForm : Form
    {

        public FSMState ControllerState;

        public GenerateRandomCardForm()
        {
            InitializeComponent();
        }

        public void DisplayCard(Card card)
        {
            txtGeneratedCardDesc.Text = card.Title.GetLocalized();
            txtGeneratedCardDesc.Text += Environment.NewLine;
            txtGeneratedCardDesc.Text += Environment.NewLine;
            foreach (Enchantment enchantment in card.Enchantments)
            {
                txtGeneratedCardDesc.Text += enchantment.TextKey;
                txtGeneratedCardDesc.Text += Environment.NewLine;
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            ControllerState.FireAction("Back", "");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            Name rarityParam = Cards_Generator.Name.NAME_NONE;  //#TODO shadowing with one control parameter :(

            switch(cmbRarity.SelectedIndex)
            {
                case 0:
                    rarityParam = "Common";
                    break;
                case 1:
                    rarityParam = "Magic";
                    break;
                case 2:
                    rarityParam = "Rare";
                    break;
            }

            Name typeAction = Cards_Generator.Name.NAME_NONE;  //#TODO shadowing with one control parameter :(

            switch (cmbType.SelectedIndex)
            {
                case 0:
                    typeAction = "GenerateCreature";
                    break;
                case 1:
                    typeAction = "GenerateEquipment";
                    break;
            }

            if(typeAction != Cards_Generator.Name.NAME_NONE && rarityParam != Cards_Generator.Name.NAME_NONE)
            {
                ControllerState.FireAction(typeAction, rarityParam);
            }
        }

        private void lblGeneratedCardTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
