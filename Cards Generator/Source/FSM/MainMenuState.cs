using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    class MainMenuState : FSMState
    {
        public override void OnAction(Name Action, Name Param)
        {
        }

        public override void OnEnter()
        {
            _mainForm = new MainForm();
            _mainForm.Show();
        }

        public override void OnExit()
        {
            _mainForm.Hide();
            _mainForm.Dispose();
        }

        private MainForm _mainForm;
    }
}
