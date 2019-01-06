using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{

    public struct BoardPoint
    {
        public int X;

        public int Y;

        public BoardPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }


    public class BoardMap
    {
        

        public enum ETileType
        {
            None,
            Empty,
            Road,
            StartPoint,
            Shop,
            Monster,
            Unusable,
            COUNT
        }

        public enum EDirection
        {
            Up,
            Right,
            Down,
            Left,
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
      
        public int SizeX
        {
            get; private set;
        }

        public int SizeY
        {
            get; private set;
        }


        public static ETileType GetRandomTileType()
        {
            return (ETileType)Globals.RandomNumberGenerator.Next((int)(ETileType.Empty), (int)(ETileType.COUNT));
        }


        public BoardMap(int sizeX, int sizeY)
        {
            Tiles = new ETileType[sizeX,sizeY];
        }

        public void SetTile(BoardPoint position, ETileType tileType)
        {
            _tiles[position.X, position.Y] = tileType;
        }

        public void SetTileChecked(BoardPoint position, ETileType tileType)
        {
            if(IsValidTile(position))
            {
                SetTile(position, tileType);
            }
        }

        public ETileType GeTile(BoardPoint position)
        {
            return _tiles[position.X, position.Y];
        }

        public ETileType GetTileChecked(BoardPoint position)
        {
            if(IsValidTile(position))
            {
                return GeTile(position);
            }
            else
            {
                return ETileType.None;
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

        public bool IsValidTile(BoardPoint position)
        {
            return position.X >= 0 && position.X < SizeX && position.Y >= 0 && position.Y < SizeY;
        }

        public bool IsClearDirection(BoardPoint position, EDirection direction)
        {

            bool isClear = false;

            if (IsValidTile(position))
            {
                switch (direction)
                {
                    case EDirection.Up:
                        isClear = position.Y - 1 >= 0 && _tiles[position.X, position.Y - 1] == BoardMap.ETileType.Empty;
                        break;
                    case EDirection.Right:
                        isClear = position.X + 1 < SizeX && _tiles[position.X + 1, position.Y] == BoardMap.ETileType.Empty;
                        break;
                    case EDirection.Down:
                        isClear = position.Y + 1 < SizeY && _tiles[position.X, position.Y + 1] == BoardMap.ETileType.Empty;
                        break;
                    case EDirection.Left:
                        isClear = position.X - 1 >= 0 && _tiles[position.X - 1, position.Y] == BoardMap.ETileType.Empty;
                        break;
                }
            }

            return isClear;
        }

        public BoardPoint GetNextTilePosition(BoardPoint position, EDirection direction)
        {
            BoardPoint nextPosition;

            switch (direction)
            {
                case EDirection.Up:
                    nextPosition = new BoardPoint(position.X, position.Y - 1);
                    break;
                case EDirection.Right:
                    nextPosition = new BoardPoint(position.X + 1, position.Y);
                    break;
                case EDirection.Down:
                    nextPosition = new BoardPoint(position.X, position.Y + 1);
                    break;
                default:  //case EDirection.Left:
                    nextPosition = new BoardPoint(position.X - 1, position.Y);
                    break;
            }
            
            return nextPosition;
        }

        public void setNeighborsUnusableIfEmpty(BoardPoint currentPos)
        {
            for (var dirI = 0; dirI < (uint)BoardMap.EDirection.COUNT; ++dirI)
            {
               BoardPoint NextPoint = GetNextTilePosition(currentPos, (EDirection)dirI);
               if(GetTileChecked(NextPoint) == ETileType.Empty)
               {
                    SetTile(NextPoint, ETileType.Unusable);
               }
            }
        }

        public bool IsEdgePosition(BoardPoint position)
        {
            return position.X == 0 || position.X == SizeX - 1 || position.Y == 0 || position.Y == SizeY - 1;
        }

        public BoardPoint GetRandomEdgePosition()
        {
            int x = 0, y = 0;

            int edge = Globals.RandomNumberGenerator.Next(0, 4);
            switch (edge)
            {
                case 0:
                    x = 0;
                    y = Globals.RandomNumberGenerator.Next(0, SizeY);
                    break;
                case 1:
                    x = SizeX - 1;
                    y = Globals.RandomNumberGenerator.Next(0, SizeY);
                    break;
                case 2:
                    x = Globals.RandomNumberGenerator.Next(0, SizeX);
                    y = 0;
                    break;
                default:
                    x = Globals.RandomNumberGenerator.Next(0, SizeX);
                    y = SizeX - 1;
                    break;
            }

            return new BoardPoint(x, y);
        }


        private ETileType[,] _tiles;

    }
}
