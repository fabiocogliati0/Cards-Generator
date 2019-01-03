using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    class GenerateMapState : FSMState
    {

        private readonly Name BackAction = "Back";
        private readonly Name GenerateAction = "Generate";

        private readonly Name BackTransition = "Back";


        public override void OnAction(Name Action, Name Param)
        {
            if(Action == BackAction)
            {
                TriggerTranstion(BackTransition);
            }
            else if(Action == GenerateAction)
            {
                GenerateMap();
            }
        }

        public override void OnEnter()
        {
            

            _form = new GenerateMapForm
            {
                ControllerState = this
            };
            GenerateMap();
            _form.Show();
        }


        private void GenerateMap()
        {
            BoardMap generatedMap = CardsGeneratorManager.GetInstance().GenerateMap(_TilesSizeX, _TilesSizeY);
            _form.SetMap(generatedMap);
        }

        public override void OnExit()
        {
            _form.Hide();
            _form.Dispose();
        }

        private const int _TilesSizeX = 50;

        private const int _TilesSizeY = 50;

 
        private GenerateMapForm _form;
    }
}
