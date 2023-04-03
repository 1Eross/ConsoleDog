using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class Rectangle
    {
        public int _RectangleX;
        public int _RectangleY;
        public int _RectangleHeight;
        public int _RectangleWidth;
        public Rectangle(int rectangleX, int rectangleY, int rectangleHeight, int rectangleWidth)
        {
            this._RectangleX = rectangleX;
            this._RectangleY = rectangleY;
            this._RectangleHeight = rectangleHeight;
            this._RectangleWidth = rectangleWidth;
        }
    }

    public class Leaf
    {
        public const int _MIN_LEAF_SIZE = 15; //*
        public const int _MAX_LEAF_SIZE = 30; //*
        public int _LeafX;
        public int _LeafY;
        public int _LeafHeight;
        public int _LeafWidth;
        public Leaf _LeafLeftChild;
        public Leaf _LeafRightChild;
        public Rectangle _LeafRoom;
        public List<Rectangle> _Halls;
        Random _Rand = new Random();

        public Leaf(int _LeafX, int _LeafY, int _LeafHeight, int _LeafWidth, Random Rand)
        {
            this._LeafX = _LeafX;
            this._LeafY = _LeafY;
            this._LeafHeight = _LeafHeight;
            this._LeafWidth = _LeafWidth;
            this._Rand = Rand;
        }
        public bool LeafSplit()
        {
            if (this._LeafRightChild != null || this._LeafLeftChild != null) // Если есть дочерний лист, то не режем
            {
                return false;
            }
            else
            {
                bool SplitHeight = _Rand.NextDouble() > 0.5; // Если рандомное число больше 0.5 то 1, иначе 0
                if (this._LeafWidth > this._LeafHeight & (double)this._LeafWidth / this._LeafHeight >= 1.25)
                {
                    SplitHeight = false;
                }
                if (this._LeafHeight > this._LeafWidth & (double)this._LeafHeight / this._LeafWidth >= 1.25)
                {
                    SplitHeight = true;
                }
                int MaxSplit = (SplitHeight ? _LeafHeight : _LeafWidth) - _MIN_LEAF_SIZE;
                if (MaxSplit <= _MIN_LEAF_SIZE)
                {
                    return false;
                }
                int SplitValue = _Rand.Next(_MIN_LEAF_SIZE, MaxSplit);
                if (SplitHeight)
                {
                    _LeafLeftChild = new Leaf(_LeafX, _LeafY, SplitValue, _LeafWidth, _Rand);
                    _LeafRightChild = new Leaf(_LeafX, _LeafY + SplitValue, _LeafHeight - SplitValue, _LeafWidth, _Rand);
                }
                else
                {
                    _LeafLeftChild = new Leaf(_LeafX, _LeafY, _LeafHeight, SplitValue, _Rand);
                    _LeafRightChild = new Leaf(_LeafX + SplitValue, _LeafY, _LeafHeight, _LeafWidth - SplitValue, _Rand);
                }
                return true;
            }
        }
        public Rectangle GetRoom(Random Rand)
        {
            if (_LeafRoom != null)
            {
                return _LeafRoom;
            }
            else
            {
                Rectangle LeftRoom = null;
                Rectangle RightRoom = null;
                if (_LeafLeftChild != null)
                {
                    LeftRoom = _LeafLeftChild.GetRoom(Rand);
                }
                if (_LeafRightChild != null)
                {
                    RightRoom = _LeafRightChild.GetRoom(Rand);
                }
                if (RightRoom == null && LeftRoom == null)
                {
                    return null;
                }
                else if (RightRoom == null)
                {
                    return LeftRoom;
                }
                else if (LeftRoom == null)
                {
                    return RightRoom;
                }
                else if (Rand.NextDouble() > 5)
                {
                    return LeftRoom;
                }
                else
                {
                    return RightRoom;
                }
            }
        }
        public void CreateHall(Rectangle Left, Rectangle Right, Random Rand)
        {
            _Halls = new List<Rectangle>();
            int RoomPoint1X = Rand.Next(Left._RectangleX + 1, Left._RectangleX + Left._RectangleWidth - 2); // {?
            int RoomPoint1Y = Rand.Next(Left._RectangleY + 1, Left._RectangleY + Left._RectangleHeight - 2);
            int RoomPoint2X = Rand.Next(Right._RectangleX + 1, Right._RectangleX + Right._RectangleWidth - 2);
            int RoomPoint2Y = Rand.Next(Right._RectangleY + 1, Right._RectangleY + Right._RectangleHeight - 2); // }
            int HallWidth = RoomPoint2X - RoomPoint1X;
            int HallHeight = RoomPoint2Y - RoomPoint1Y;
            if (HallWidth < 0)
            {
                if (HallHeight < 0)
                {
                    if (Rand.NextDouble() > 0.5)
                    {
                        _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                    }
                    else
                    {
                        _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                    }
                }
                else if (HallHeight > 0)
                {
                    if (Rand.NextDouble() > 0.5)
                    {
                        _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                    }
                    else
                    {
                        _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                    }
                }
                else
                {
                    _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                }
            }
            else if (HallWidth > 0)
            {
                if (HallHeight < 0)
                {
                    if (Rand.NextDouble() > 0.5)
                    {
                        _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                    }
                    else
                    {
                        _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                    }
                }
                else if (HallHeight > 0)
                {
                    if (Rand.NextDouble() > 0.5)
                    {
                        _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                    }
                    else
                    {
                        _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                    }
                }
                else
                {
                    _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                }
            }
            else
            {
                if (HallHeight < 0)
                {
                    _Halls.Add(new Rectangle(RoomPoint2X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                }
                else if (HallHeight > 0)
                {
                    _Halls.Add(new Rectangle(RoomPoint1X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                }
            }
        }
        public void CreateRoomsForLeafs(Random Rand)
        {
            if (_LeafLeftChild != null || _LeafRightChild != null)
            {
                if (_LeafLeftChild != null)
                {
                    _LeafLeftChild.CreateRoomsForLeafs(Rand);
                }
                if (_LeafRightChild != null)
                {
                    _LeafRightChild.CreateRoomsForLeafs(Rand);
                }
                if (_LeafLeftChild != null & _LeafRightChild != null)
                {
                    CreateHall(_LeafLeftChild.GetRoom(Rand), _LeafRightChild.GetRoom(Rand), Rand);
                }
            }
            else
            {
                int RoomHeight = _Rand.Next(7, _LeafHeight - 2); //*{}
                int RoomWidth = _Rand.Next(7, _LeafWidth - 2); //*{}
                int RoomPosX = _Rand.Next(1, _LeafWidth - RoomWidth - 2);
                int RoomPosY = _Rand.Next(1, _LeafHeight - RoomHeight - 2);
                _LeafRoom = new Rectangle(_LeafX + RoomPosX, _LeafY + RoomPosY, RoomHeight, RoomWidth);
            }
        }
        public static List<Leaf> LeafsCreate(int _RootLeafX, int _RootLeafY, int _MapHeight, int _MapWidth, Random Rand) // Функция создающая лифы
        {
            List<Leaf> _leafs = new List<Leaf>();
            Leaf Root = new Leaf(_RootLeafX, _RootLeafY, _MapHeight, _MapWidth, Rand);
            _leafs.Add(Root);
            bool DidSplit = true;
            while (DidSplit)
            {
                DidSplit = false;
                foreach (Leaf l in _leafs.ToArray())
                {
                    if (l._LeafLeftChild == null && l._LeafRightChild == null)
                    {
                        if (l._LeafWidth > _MAX_LEAF_SIZE || l._LeafHeight > _MAX_LEAF_SIZE || Rand.NextDouble() > 0.25)
                        {
                            if (l.LeafSplit()) // Что это ?
                            {
                                _leafs.Add(l._LeafLeftChild);
                                _leafs.Add(l._LeafRightChild);
                                DidSplit = true;
                            }
                        }
                    }
                }
            }
            Root.CreateRoomsForLeafs(Rand);
            return _leafs;
        }

    }

    public class ConsoleDogMap
    {
        public static readonly int _MapHeight = 35; // Создать класс консоль и притянуть оттуда
        public static readonly int _MapWidth = 85; // Создать класс консоль и притянуть оттуда
        public static Cell[,] _Cells = new Cell[_MapHeight, _MapWidth]; // Точно ли статик

        public static void MapCreation(Random Rand)
        {
            for (int y = 0; y < _MapHeight; y++)
            {
                for (int x = 0; x < _MapWidth; x++)
                {
                    ConsoleDogMap._Cells[y, x] = new Cell(x, y, false, false);
                }
            }
            List<Leaf> _leafs = new List<Leaf>();
            _leafs = Leaf.LeafsCreate(0, 0, _MapHeight, _MapWidth, Rand);
            List<Rectangle> _Halls = new List<Rectangle>();
            foreach (Leaf l in _leafs)
            {
                if (l._Halls != null)
                {
                    foreach (Rectangle r in l._Halls)
                    {
                        RectangleHallsCreate(r._RectangleX, r._RectangleY, r._RectangleHeight, r._RectangleWidth);

                    }
                }
                if (l._LeafLeftChild == null || l._LeafRightChild == null)
                {
                    RectangleRoomCreate(l._LeafRoom._RectangleX, l._LeafRoom._RectangleY,
                    l._LeafRoom._RectangleHeight, l._LeafRoom._RectangleWidth);

                }

            }

        }

        public static void RectangleRoomCreate(int _RectanglePlacementX, int _RectanglePlacementY, int _RectangleHeight, int _RectangleWidth)
        {
            for (int y = _RectanglePlacementY - 1; y < _RectangleHeight + _RectanglePlacementY + 1; y++)
            {
                for (int x = _RectanglePlacementX - 1; x < _RectangleWidth + _RectanglePlacementX + 1; x++)
                {
                    if (y == _RectanglePlacementY - 1 || y == _RectangleHeight + _RectanglePlacementY
                    || x == _RectanglePlacementX - 1 || x == _RectangleWidth + _RectanglePlacementX)
                    {
                        ConsoleDogMap._Cells[y, x]._IsMap = true;
                        ConsoleDogMap._Cells[y, x]._IsWalkable = false;
                    } //// Если добавить отрицание возможности пройти, то будет дeлать стены внутри комнат
                    else
                    {
                        ConsoleDogMap._Cells[y, x]._IsMap = true;
                        ConsoleDogMap._Cells[y, x]._IsWalkable = true;
                    }
                }
            }
        }
        public static void RectangleHallsCreate(int _RectanglePlacementX, int _RectanglePlacementY, int _RectangleHeight, int _RectangleWidth)
        {
            for (int y = _RectanglePlacementY - 1; y < _RectangleHeight + _RectanglePlacementY + 1; y++)
            {
                for (int x = _RectanglePlacementX - 1; x < _RectangleWidth + _RectanglePlacementX + 1; x++)
                {
                    if ((y == _RectanglePlacementY - 1 || y == _RectangleHeight + _RectanglePlacementY
                    || x == _RectanglePlacementX - 1 || x == _RectangleWidth + _RectanglePlacementX))
                    {
                        ConsoleDogMap._Cells[y, x]._IsMap = true;
                        ConsoleDogMap._Cells[y, x]._IsWalkable = true;
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


