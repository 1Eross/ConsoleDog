using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Map
{
    public class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class Cell
    {
        public int _PosX;
        public int _PosY;
        public bool _IsWalkable;
        public bool _IsMap;
        public bool _IsExplored;
        public Cell(int _PosX, int _PosY, bool _IsWalkable, bool _IsMap, bool isExplored)
        {
            this._PosX = _PosX;
            this._PosY = _PosY;
            this._IsWalkable = _IsWalkable;
            this._IsMap = _IsMap;
            _IsExplored = isExplored;
        }

    }
    public class Room
    {
        public int _RectangleX;
        public int _RectangleY;
        public int _RectangleHeight;
        public int _RectangleWidth;
        public Room(int rectangleX, int rectangleY, int rectangleHeight, int rectangleWidth)
        {
            this._RectangleX = rectangleX;
            this._RectangleY = rectangleY;
            this._RectangleHeight = rectangleHeight;
            this._RectangleWidth = rectangleWidth;
        }
    }

    public class Hall
    {
        public int _RectangleX;
        public int _RectangleY;
        public int _RectangleHeight;
        public int _RectangleWidth;
        public int _HallEnterX;
        public int _HallEnterY;
        public Hall(int rectangleX, int rectangleY, int rectangleHeight, int rectangleWidth)
        {
            this._RectangleX = rectangleX;
            this._RectangleY = rectangleY;
            this._RectangleHeight = rectangleHeight;
            this._RectangleWidth = rectangleWidth;
        }
    }
}
