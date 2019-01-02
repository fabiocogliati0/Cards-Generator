using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    class MainMenuState : FSMState
    {
        private static readonly Name ToGeneratorAction = "ToGenerator";

        private static readonly Name ToGeneratorTransition = "ToGenerator";


        public override void OnAction(Name Action, Name Param)
        {
            if(Action == ToGeneratorAction)
            {
                TriggerTranstion(ToGeneratorTransition);
            }
        }

        public override void OnEnter()
        {
            _mainForm = new MainForm();
            _mainForm.ControllerState = this;
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
