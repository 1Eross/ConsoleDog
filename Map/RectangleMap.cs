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
        public char _Icon;
        public Cell(int _PosX, int _PosY, bool _IsWalkable, char _Icon)
        {
            this._PosX = _PosX;
            this._PosY = _PosY;
            this._IsWalkable = _IsWalkable;
            this._Icon = _Icon;
        }
    }
    internal class ConsoleDogMap
    {
        public static readonly int _MapHeight = 80; // Изменяемое
        public static readonly int _MapWidth = 35; // Изменяемое
        public Cell[,] _Cells = new Cell[_MapHeight, _MapWidth];
        public ConsoleDogMap()
        {
            for (int i = 0; i < _MapHeight; i++)
            {
                for (int j = 0; j < _MapWidth; j++)
                {
                    if (i == 0 || j == 0 || j == _MapWidth - 1 || i == _MapHeight - 1)
                    {
                        this._Cells[i, j] = new Cell(i, j, false, ' ');
                    }
                    else
                    {
                        if (i == 1 || j == 1 || j == _MapWidth - 2 || i == _MapHeight - 2)
                        {
                            this._Cells[i, j] = new Cell(i, j, false, '#');
                        }
                        else
                        {
                            this._Cells[i, j] = new Cell(i, j, true, '.'); // Не совсем правильное задание карты
                        }
                    }

                }

            }

        }
        public int Get_Map_Width()
        {
            return _MapWidth;
        }
        public int Get_Map_Height()
        {
            return _MapHeight;
        }
        public char Get_CellIcon(int x, int y)
        {
            return _Cells[x, y]._Icon;
        }
    }
    internal class Class1
    {
    }
}
