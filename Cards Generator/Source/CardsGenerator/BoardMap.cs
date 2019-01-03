using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{

    public class BoardMap
    {

        public enum ETileType
        {
            Empty,
            Road,
            StartPoint,
            Shop,
            Monster,
            COUNT
        }



        public ETileType[,] Tiles
        {
            get
            {
                return _tiles;
            }
            private set
            {
                _tiles = value;
                SizeX = _tiles.GetLength(0);
                SizeY = _tiles.GetLength(1);
            }
        }

        public static ETileType GetRandomTileType()
        {
            return (ETileType)Globals.RandomNumberGenerator.Next((int)(ETileType.Empty), (int)(ETileType.COUNT));
        }

        public int SizeX
        {
            get; private set;
        }

        public int SizeY
        {
            get; private set;
        }

        public void SetTile(int x, int y, ETileType tileType)
        {
            if(x >= 0 && x < SizeX && y >=0 && y < SizeY)
            {
                _tiles[x, y] = tileType;
            }
        }

        public void Clear()
        {
            for(var i =0; i<SizeX; ++i)
            {
                for(var j=0; j<SizeY; ++j)
                {
                    _tiles[i, j] = ETileType.Empty;
                }
            }
        }

        public BoardMap(int sizeX, int sizeY)
        {
            Tiles = new ETileType[sizeX,sizeY];
        }


        private ETileType[,] _tiles;
    }
}
