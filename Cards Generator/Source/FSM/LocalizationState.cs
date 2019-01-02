using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    class LocalizationState : FSMState
    {

        private static readonly Name ProceedAction = "Proceed";
        private static readonly Name ChangeLanguageAction = "ChangeLanguage";
        private static readonly Name EnglishParam = "English";
        private static readonly Name ItalianParam = "Italian";

        private static readonly Name ProceedTransition = "Proceed";

        
        public override void OnEnter()
        {
            _localizationForm = new LocalizationForm
            {
                ControllerState = this
            };
            _localizationForm.Show();
        }

        public override void OnExit()
        {
            _localizationForm.Hide();
            _localizationForm.Dispose();
        }

        public override void OnAction(Name Action, Name Param)
        {
            if (Action == ProceedAction)
            {
                TriggerTranstion(ProceedTransition);
            }
            else if (Action == ChangeLanguageAction)
            {
                if (Param == EnglishParam)
                {
                    Globals.Language = Globals.ELanguage.english;
                    _localizationForm.RefreshContent();

                }
                else if (Param == ItalianParam)
                {
                    Globals.Language = Globals.ELanguage.italian;
                    _localizationForm.RefreshContent();
                }
            }
        }


        private LocalizationForm _localizationForm;
    }
}
