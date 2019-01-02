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
        private static readonly Name ToMapGeneratorAction = "ToMapGenerator";

        private static readonly Name ToGeneratorTransition = "ToGenerator";
        private static readonly Name ToMapGeneratorTransition = "ToMapGenerator";


        public override void OnAction(Name Action, Name Param)
        {
            if(Action == ToGeneratorAction)
            {
                TriggerTranstion(ToGeneratorTransition);
            }
            else if(Action == ToMapGeneratorAction)
            {
                TriggerTranstion(ToMapGeneratorTransition);
            }
        }

        public override void OnEnter()
        {
            _mainForm = new MainForm
            {
                ControllerState = this
            };
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
