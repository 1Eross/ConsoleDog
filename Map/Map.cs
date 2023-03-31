using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Map
{
    public class Cell
    {
        public int _PosX;
        public int _PosY;
        public bool _IsWalkable;
        public bool _IsMap;
        public Cell(int _PosX, int _PosY, bool _IsWalkable, bool _IsMap)
        {
            this._PosX = _PosX;
            this._PosY = _PosY;
            this._IsWalkable = _IsWalkable;
            this._IsMap = _IsMap;

        }
    }

    public class ConsoleDogMap
    {
        public static readonly int _MapHeight = 35; // Создать класс консоль и притянуть оттуда
        public static readonly int _MapWidth = 85; // Создать класс консоль и притянуть оттуда
        public static Cell[,] _Cells = new Cell[_MapHeight, _MapWidth]; // Точно ли статик

        public static void MapCreation()
        {
            for (int y = 0; y < _MapHeight; y++)
            {
                for (int x = 0; x < _MapWidth; x++)
                {
                    ConsoleDogMap._Cells[y, x] = new Cell(x, y, false, false);
                }

            }
        }

        public static void RectangleCreate(int _RectangleHeight, int _RectangleWidth, int _RectanglePlacementX, int _RectanglePlacementY)
        {
            for (int y = _RectanglePlacementY; y < _RectangleHeight + _RectanglePlacementY; y++)
            {
                for (int x = _RectanglePlacementX; x < _RectangleWidth + _RectanglePlacementX; x++)
                {
                    if (y == _RectanglePlacementY || y == _RectangleHeight + _RectanglePlacementY - 1
                    || x == _RectanglePlacementX || x == _RectangleWidth + _RectanglePlacementX - 1)
                    {
                        ConsoleDogMap._Cells[y, x]._IsMap = true;
                    }
                    else
                    {
                        ConsoleDogMap._Cells[y, x]._IsMap = true;
                        ConsoleDogMap._Cells[y, x]._IsWalkable = true;
                    }
                }
            }
        }
    }
}
