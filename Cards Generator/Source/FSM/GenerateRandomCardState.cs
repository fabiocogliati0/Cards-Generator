using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    class GenerateRandomCardState : FSMState
    {

        private static readonly Name BackAction = "Back";
        private static readonly Name GenerateCreatureAction = "GenerateCreature";
        private static readonly Name GenerateEquipmentAction = "GenerateEquipment";
        private static readonly Name CommonRarityParameter = "Common";
        private static readonly Name MagicRarityParameter = "Magic";
        private static readonly Name RareRarityParameter = "Rare";

        private static readonly Name BackTransition = "Back";
        

        public override void OnAction(Name Action, Name Param)
        {
            if(Action == BackAction)
            {
                TriggerTranstion(BackTransition);
            }
            else if(Action == GenerateCreatureAction || Action == GenerateEquipmentAction)
            {
                ECardRarity requestedRarity = ECardRarity.None;

                if(Param == CommonRarityParameter)
                {
                    requestedRarity = ECardRarity.Common;
                }
                else if (Param == MagicRarityParameter)
                {
                    requestedRarity = ECardRarity.Magic;
                }
                else if (Param == RareRarityParameter)
                {
                    requestedRarity = ECardRarity.Rare;
                }

                if (requestedRarity != ECardRarity.None)
                {
                    if (Action == GenerateCreatureAction)
                    {
                        CreatureCard creatureCard = CardsGeneratorManager.GetInstance().GenerateRandomCard<CreatureCard>(requestedRarity);
                        _generateRandomCardForm.DisplayCard(creatureCard);
                    }
                    else
                    {
                        EquipmentCard equipmentCard = CardsGeneratorManager.GetInstance().GenerateRandomCard<EquipmentCard>(requestedRarity);
                        _generateRandomCardForm.DisplayCard(equipmentCard);
                    }
                }
            }
        }

        public override void OnEnter()
        {
            _generateRandomCardForm = new GenerateRandomCardForm();
            _generateRandomCardForm.ControllerState = this;
            _generateRandomCardForm.Show();
        }

        public override void OnExit()
        {
            _generateRandomCardForm.Hide();
            _generateRandomCardForm.Dispose();
        }


        private GenerateRandomCardForm _generateRandomCardForm;
    }
}
