using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    class CreditState : FSMState
    {

        private static readonly Name BackAction = "Back";
        private static readonly Name BackTransition = "Back";

        public override void OnAction(Name Action, Name Param)
        {
            if (Action == BackAction)
            {
                TriggerTranstion(BackTransition);
            }
        }

        public override void OnEnter()
        {
            _creditForm = new CreditForm
            {
                ControllerState = this
            };
            _creditForm.Show();
        }

        public override void OnExit()
        {
            _creditForm.Hide();
            _creditForm.Dispose();
        }

        private CreditForm _creditForm;
    }
}
