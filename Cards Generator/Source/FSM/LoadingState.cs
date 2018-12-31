using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    class LoadingState : FSMState
    {

        private static readonly Name ProceedTransition = "Proceed";

        private static readonly Name CloseAction = "Close";


        public override void OnEnter()
        {
            _loadingForm = new LoadingForm();
            _loadingForm.ControllerState = this;
            _loadingForm.Show();
        }

        public override void OnExit()
        {
            _loadingForm.Hide();
            _loadingForm.Dispose();
        }

        public override void OnAction(Name Action, Name Param)
        {
            if(Action == CloseAction)
            {
                TriggerTranstion(ProceedTransition);
            }
        }


        private LoadingForm _loadingForm;
    }
}
