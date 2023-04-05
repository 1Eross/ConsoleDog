using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Map
{
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
        public Room _LeafRoom;
        public List<Hall> _Halls;

        public Leaf(int _LeafX, int _LeafY, int _LeafHeight, int _LeafWidth)
        {
            this._LeafX = _LeafX;
            this._LeafY = _LeafY;
            this._LeafHeight = _LeafHeight;
            this._LeafWidth = _LeafWidth;
        }
        public bool LeafSplit()
        {
            if (this._LeafRightChild != null || this._LeafLeftChild != null) // Если есть дочерний лист, то не режем
            {
                return false;
            }
            else
            {
                bool SplitHeight = Program.Rand.NextDouble() > 0.5; // Если рандомное число больше 0.5 то 1, иначе 0
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
                int SplitValue = Program.Rand.Next(_MIN_LEAF_SIZE, MaxSplit);
                if (SplitHeight)
                {
                    _LeafLeftChild = new Leaf(_LeafX, _LeafY, SplitValue, _LeafWidth);
                    _LeafRightChild = new Leaf(_LeafX, _LeafY + SplitValue, _LeafHeight - SplitValue, _LeafWidth);
                }
                else
                {
                    _LeafLeftChild = new Leaf(_LeafX, _LeafY, _LeafHeight, SplitValue);
                    _LeafRightChild = new Leaf(_LeafX + SplitValue, _LeafY, _LeafHeight, _LeafWidth - SplitValue);
                }
                return true;
            }
        }
        public Room GetRoom()
        {
            if (_LeafRoom != null)
            {
                return _LeafRoom;
            }
            else
            {
                Room LeftRoom = null;
                Room RightRoom = null;
                if (_LeafLeftChild != null)
                {
                    LeftRoom = _LeafLeftChild.GetRoom();
                }
                if (_LeafRightChild != null)
                {
                    RightRoom = _LeafRightChild.GetRoom();
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
                else if (Program.Rand.NextDouble() > 5)
                {
                    return LeftRoom;
                }
                else
                {
                    return RightRoom;
                }
            }
        }
        public void CreateHall(Room Left, Room Right)
        {
            _Halls = new List<Hall>();
            int RoomPoint1X = Program.Rand.Next(Left._RectangleX + 1, Left._RectangleX + Left._RectangleWidth - 2); // {?
            int RoomPoint1Y = Program.Rand.Next(Left._RectangleY + 1, Left._RectangleY + Left._RectangleHeight - 2);
            int RoomPoint2X = Program.Rand.Next(Right._RectangleX + 1, Right._RectangleX + Right._RectangleWidth - 2);
            int RoomPoint2Y = Program.Rand.Next(Right._RectangleY + 1, Right._RectangleY + Right._RectangleHeight - 2); // }
            int HallWidth = RoomPoint2X - RoomPoint1X;
            int HallHeight = RoomPoint2Y - RoomPoint1Y;
            if (HallWidth < 0)
            {
                if (HallHeight < 0)
                {
                    if (Program.Rand.NextDouble() > 0.5)
                    {
                        _Halls.Add(new Hall(RoomPoint2X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Hall(RoomPoint2X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                    }
                    else
                    {
                        _Halls.Add(new Hall(RoomPoint1X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Hall(RoomPoint2X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                    }
                }
                else if (HallHeight > 0)
                {
                    if (Program.Rand.NextDouble() > 0.5)
                    {
                        _Halls.Add(new Hall(RoomPoint2X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Hall(RoomPoint2X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                    }
                    else
                    {
                        _Halls.Add(new Hall(RoomPoint1X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Hall(RoomPoint2X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                    }
                }
                else
                {
                    _Halls.Add(new Hall(RoomPoint2X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                }
            }
            else if (HallWidth > 0)
            {
                if (HallHeight < 0)
                {
                    if (Program.Rand.NextDouble() > 0.5)
                    {
                        _Halls.Add(new Hall(RoomPoint1X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Hall(RoomPoint1X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                    }
                    else
                    {
                        _Halls.Add(new Hall(RoomPoint2X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Hall(RoomPoint1X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                    }
                }
                else if (HallHeight > 0)
                {
                    if (Program.Rand.NextDouble() > 0.5)
                    {
                        _Halls.Add(new Hall(RoomPoint2X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Hall(RoomPoint1X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                    }
                    else
                    {
                        _Halls.Add(new Hall(RoomPoint1X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                        _Halls.Add(new Hall(RoomPoint1X, RoomPoint2Y, 1, Math.Abs(HallWidth)));
                    }
                }
                else
                {
                    _Halls.Add(new Hall(RoomPoint1X, RoomPoint1Y, 1, Math.Abs(HallWidth)));
                }
            }
            else
            {
                if (HallHeight < 0)
                {
                    _Halls.Add(new Hall(RoomPoint2X, RoomPoint2Y, Math.Abs(HallHeight), 1));
                }
                else if (HallHeight > 0)
                {
                    _Halls.Add(new Hall(RoomPoint1X, RoomPoint1Y, Math.Abs(HallHeight), 1));
                }
            }
        }
        public void CreateRoomsForLeafs()
        {
            if (_LeafLeftChild != null || _LeafRightChild != null)
            {
                if (_LeafLeftChild != null)
                {
                    _LeafLeftChild.CreateRoomsForLeafs();
                }
                if (_LeafRightChild != null)
                {
                    _LeafRightChild.CreateRoomsForLeafs();
                }
                if (_LeafLeftChild != null & _LeafRightChild != null)
                {
                    CreateHall(_LeafLeftChild.GetRoom(), _LeafRightChild.GetRoom());
                }
            }
            else
            {
                int RoomHeight = Program.Rand.Next(7, _LeafHeight - 2); //*{}
                int RoomWidth = Program.Rand.Next(7, _LeafWidth - 2); //*{}
                int RoomPosX = Program.Rand.Next(1, _LeafWidth - RoomWidth - 2);
                int RoomPosY = Program.Rand.Next(1, _LeafHeight - RoomHeight - 2);
                _LeafRoom = new Room(_LeafX + RoomPosX, _LeafY + RoomPosY, RoomHeight, RoomWidth);
            }
        }
        public static List<Leaf> LeafsCreate(int _RootLeafX, int _RootLeafY, int _MapHeight, int _MapWidth) // Функция создающая лифы
        {
            List<Leaf> _leafs = new List<Leaf>();
            Leaf Root = new Leaf(_RootLeafX, _RootLeafY, _MapHeight, _MapWidth);
            _leafs.Add(Root);
            bool DidSplit = true;
            while (DidSplit)
            {
                DidSplit = false;
                foreach (Leaf l in _leafs.ToArray())
                {
                    if (l._LeafLeftChild == null && l._LeafRightChild == null)
                    {
                        if (l._LeafWidth > _MAX_LEAF_SIZE || l._LeafHeight > _MAX_LEAF_SIZE || Program.Rand.NextDouble() > 0.25)
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
            Root.CreateRoomsForLeafs();
            return _leafs;
        }

    }
}
