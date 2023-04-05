using OpenTK;
using OpenTK.Graphics.OpenGL;
using RLNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDog.Actor;
using ConsoleDog.Map;
using ConsoleDog.Actor.Monsters;

namespace ConsoleDog.Map
{
    public class Map
    {
        private static readonly int _MapHeight = 35; // Создать класс консоль и притянуть оттуда
        private static readonly int _MapWidth = 85; // Создать класс консоль и притянуть оттуда
        private static Cell[,] _Cells = new Cell[_MapHeight, _MapWidth]; // Точно ли статик
        private static List<Monster> _MonsterList = new List<Monster>();
        private static List<Leaf> _leafs = new List<Leaf>();
        private static List<Room> _Halls = new List<Room>();

        public Cell GetCell(int x, int y)
        {
            return _Cells[y, x];
        }

        private static void RectangleCreate(int _RectanglePlacementX, int _RectanglePlacementY, int _RectangleHeight, int _RectangleWidth)
        {
            for (int y = _RectanglePlacementY - 1; y < _RectangleHeight + _RectanglePlacementY + 1; y++)
            {
                for (int x = _RectanglePlacementX - 1; x < _RectangleWidth + _RectanglePlacementX + 1; x++)
                {
                    if (y == _RectanglePlacementY - 1 || y == _RectangleHeight + _RectanglePlacementY
                    || x == _RectanglePlacementX - 1 || x == _RectangleWidth + _RectanglePlacementX)
                    {
                        Map._Cells[y, x]._IsMap = true;
                    }
                    else
                    {
                        Map._Cells[y, x]._IsMap = true;
                        Map._Cells[y, x]._IsWalkable = true;
                    }
                }
            }
        }

        public static void MapCreation(Random Rand)
        {
            for (int y = 0; y < _MapHeight; y++)
            {
                for (int x = 0; x < _MapWidth; x++)
                {
                    Map._Cells[y, x] = new Cell(x, y, false, false, true);
                }
            }
            _leafs = Leaf.LeafsCreate(0, 0, _MapHeight, _MapWidth);
            foreach (Leaf l in _leafs)
            {
                if (l._LeafLeftChild == null || l._LeafRightChild == null)
                {
                    RectangleCreate(l._LeafRoom._RectangleX, l._LeafRoom._RectangleY,
                    l._LeafRoom._RectangleHeight, l._LeafRoom._RectangleWidth);
                }
                if (l._Halls != null)
                {
                    foreach (Hall r in l._Halls)
                    {
                        RectangleCreate(r._RectangleX, r._RectangleY, r._RectangleHeight, r._RectangleWidth);
                    }
                }

            }
/*            Map.PlacePlayer();//Написать*/
            Map.PlaceMonsters();

        }
        public static void Draw(RLConsole _MapConsole)
        {
            _MapConsole.Clear();
            foreach(Cell _Cell in _Cells)
            {
                SetConsoleSymbolforCell(_MapConsole, _Cell);
            }
            foreach(Monster monster in _MonsterList)
            {
                monster.Draw(_MapConsole);
            }
        }
        
        private static void SetConsoleSymbolforCell(RLConsole _MapConsole, Cell _Cell)
        {
            if (_Cell._IsMap)
            {
                if (_Cell._IsWalkable)
                {
                    _MapConsole.Set(_Cell._PosX, _Cell._PosY, Colors.Colors.FloorFov, Colors.Colors.FloorBackgroundFov, '.');
                }
                else
                {
                    _MapConsole.Set(_Cell._PosX, _Cell._PosY, Colors.Colors.WallFov, Colors.Colors.WallBackgroundFov, '#');
                }
            }
            /*            if (!_Cell.IsExplored) // Нет поля зрения, поэтому бесполезно
                        {
                            return;
                        }
                        if (IsInFov(_Cell._PosX, _Cell._PosY))
                        {
                            if (_Cell._IsWalkable)
                            {
                                _MapConsole.Set(_Cell._PosX, _Cell._PosY, RLColor.White, null, '.');
                            }
                            else
                            {
                                _MapConsole.Set(_Cell._PosX, _Cell._PosY, RLColor.White, null, '#');
                            }
                        }
                        else
                        {
                            if (_Cell._IsWalkable)
                            {
                                _MapConsole.Set(_Cell._PosX, _Cell._PosY, RLColor.Gray, null, '.');
                            }
                            else
                            {
                                _MapConsole.Set(_Cell._PosX, _Cell._PosY, RLColor.Gray, null, '.');
                            }
                        }*/
        }


        public static bool SetActorPosition(Player person, int x, int y)
        {
            if (_Cells[y, x]._IsWalkable)
            {
                _Cells[person.Y, person.X]._IsWalkable = true;
                person.X = x;
                person.Y = y;
                _Cells[person.Y, person.X]._IsWalkable = false;
/*                if (person is Player)
                {
                    UpdatePlayerFov();
                }*/
                return true;
            }
            return false;
        }
        public static void AddMonster(Monster monster)
        {
            _MonsterList.Add(monster);
            _Cells[monster.Y, monster.X]._IsWalkable = false;
        }
        public static void RemoveMonster(Monster monster)
        {
            Map._MonsterList.Remove(monster);
            // After removing the monster from the map, make sure the cell is walkable again
            Map._Cells[monster.Y, monster.X]._IsWalkable = true;
        }

        public static Monster GetMonsterAt(int x, int y)
        {
            return Map._MonsterList.FirstOrDefault(m => m.X == x && m.Y == y); //???
        }

        public static Point GetRandomWalkableLocationOfRoom(Room room) 
        {
            if (DoesRoomHaveWalkableSpace(room))
            {
                int x = Program.Rand.Next(room._RectangleX, room._RectangleX + room._RectangleWidth);
                int y = Program.Rand.Next(room._RectangleY, room._RectangleY + room._RectangleHeight);
                if (_Cells[y, x]._IsWalkable)
                {
                    return new Point(x,y);
                }

            }
            return null;
        }
        public static bool DoesRoomHaveWalkableSpace(Room room)
        {
            for(int y = room._RectangleY; y < room._RectangleHeight + room._RectangleY; y++)
            {
                for (int x = room._RectangleX; y < room._RectangleWidth + room._RectangleX; x++)
                {
                    if (_Cells[y, x]._IsWalkable)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static void PlaceMonsters()
        {
            foreach (Leaf leaf in _leafs)
            {
                if(leaf._LeafRoom != null)
                {
                    if(Program.Rand.NextDouble() > 0.5)
                    {
                        var numberOfMonsters = Program.Rand.Next(2,6);
                        for(int i = 0; i < numberOfMonsters; i++)
                        {
                            Point randomLocation = Map.GetRandomWalkableLocationOfRoom(leaf._LeafRoom);
                            if (randomLocation != null)
                            {
                                var monster = Kobold.Create(1);
                                monster.X = randomLocation.x;
                                monster.Y = randomLocation.y;
                                Map.AddMonster(monster);
                            }
                        }
                    }
                }
            }
        }
    }
}


