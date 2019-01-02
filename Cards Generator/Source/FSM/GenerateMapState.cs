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
            _tiles = new int[_TilesSizeX,_TilesSizeY];
            
            _form = new GenerateMapForm();
            _form.ControllerState = this;
            GenerateMap();
            _form.Show();
        }


        private void GenerateMap()
        {
            for (var i = 0; i < _TilesSizeX; ++i)
            {
                for (var j = 0; j < _TilesSizeY; ++j)
                {
                    _tiles[i, j] = Globals.RandomNumberGenerator.Next(_MinTileValue, _MaxTileValue);
                }
            }

            _form.SetMap(_tiles);
        }

        public override void OnExit()
        {
            _form.Hide();
            _form.Dispose();
        }

        private const int _TilesSizeX = 20;

        private const int _TilesSizeY = 20;

        private const int _MinTileValue = 0;

        private const int _MaxTileValue = 5;


        private GenerateMapForm _form;

        private int[,] _tiles;
    }
}
