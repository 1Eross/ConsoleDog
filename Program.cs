using OpenTK.Platform.Windows;
using RLNET;
using RogueSharp;
using RogueSharp.MapCreation;
using System;

public class Person
{

}

public class Cell
{
    public int _PosX;
    public int _PosY;
    public bool _IsWalkable;
    public char _Icon;
    public Cell(int _PosX, int _PosY, char _Icon)
    {
        this._PosX = _PosX;
        this._PosY = _PosY;
        this._Icon = _Icon;
    }
}
public class Map
{
    public static readonly int _MapHeight = 10; // Изменяемое
    public static readonly int _MapWidth = 10; // Изменяемое
    public Cell[,] _Cells = new Cell[_MapHeight, _MapWidth];
    public Map()
    {
        for (int i = 0; i < _MapWidth; i++)
        {
            for (int j = 0; j < _MapHeight; j++)
            {
                this._Cells[i, j] = new Cell(i, j, '#');
            }
        }
    }
    public char Get_CellIcon(int x, int y)
    {
        return _Cells[x, y]._Icon;
    }
}

public class Program
{
    private static Map OurMap = new Map();
    private static RLConsole _MapConsole;
    static readonly int _MapConsoleWidth = 80;
    static readonly int _MapConsoleHeight = 35;
    private static RLConsole _StatsConsole;
    private static readonly int _StatsConsoleWidth = 13;
    private static readonly int _StatsConsoleHeight = 13;
    private static RLConsole _MessagesConsole;
    private static readonly int _MessagesConsoleWidth = _MapConsoleWidth - _StatsConsoleWidth;
    private static readonly int _MessagesConsoleHeight = _StatsConsoleHeight;
    private static RLRootConsole _RootConsole;
    static readonly int _RootConsoleWidth = _MapConsoleWidth;
    static readonly int _RootConsoleHeight = _MapConsoleHeight + _StatsConsoleHeight;
    public static void Main()
    {

        string fontFileName = "ascii_8x8.png";
        string ConsoleTitle = "ABOBA";
        _RootConsole = new RLRootConsole(fontFileName, _RootConsoleWidth, _RootConsoleHeight, 8, 8, 2f, ConsoleTitle);
        _MapConsole = new RLConsole(_RootConsoleWidth, _RootConsoleHeight);
        _StatsConsole = new RLConsole(_StatsConsoleWidth, _StatsConsoleHeight);
        _MessagesConsole = new RLConsole(_MessagesConsoleWidth, _MessagesConsoleHeight);
        _RootConsole.Update += OnRootConsoleUpdate;
        _RootConsole.Render += OnRootConsoleRender;
        _RootConsole.Run();
    }
    static void OnRootConsoleUpdate(object sender, EventArgs e)
    {
        RLKeyPress keyPress = _RootConsole.Keyboard.GetKeyPress();
        _MapConsole.SetBackColor(0, 0, _MapConsoleWidth, _MapConsoleHeight, RLColor.Green);
        _StatsConsole.SetBackColor(0, 0, _StatsConsoleWidth, _StatsConsoleHeight, RLColor.Brown);
        _StatsConsole.Print(0, 0, "STATS", RLColor.White);
        _MessagesConsole.SetBackColor(0, 0, _MessagesConsoleWidth, _MessagesConsoleHeight, RLColor.Blue);
        _MessagesConsole.Print(0, 0, "MESSAGES", RLColor.White);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _MapConsole.Print(i, j, Convert.ToString(OurMap.Get_CellIcon(i, j)), RLColor.White);
            }
        }

        if (keyPress != null)
        {
            _RootConsole.Clear();
            if (keyPress.Key == RLKey.Up)
            {
                _MapConsole.Print(10, 0, "UP", RLColor.White);
                _MessagesConsole.Print(10, 0, "UP", RLColor.White);
                _StatsConsole.Print(6, 0, "UP", RLColor.White);
            }
            if (keyPress.Key == RLKey.Left)
            {
                _MapConsole.Print(10, 0, "Left", RLColor.White);
                _MessagesConsole.Print(10, 0, "Left", RLColor.White);
                _StatsConsole.Print(6, 0, "Left", RLColor.White);
            }
            if (keyPress.Key == RLKey.Right)
            {
                _MapConsole.Print(10, 0, "Right", RLColor.White);
                _MessagesConsole.Print(10, 0, "Right", RLColor.White);
                _StatsConsole.Print(6, 0, "Right", RLColor.White);
            }
            if (keyPress.Key == RLKey.Down)
            {
                _MapConsole.Print(10, 0, "Down", RLColor.White);
                _MessagesConsole.Print(10, 0, "Down", RLColor.White);
                _StatsConsole.Print(6, 0, "Down", RLColor.White);
            }
        }

    }
    static void OnRootConsoleRender(object sender, EventArgs e)
    {
        RLConsole.Blit(_MapConsole, 0, 0, _MapConsoleWidth, _MapConsoleHeight, _RootConsole, 0, 0);
        RLConsole.Blit(_StatsConsole, 0, 0, _StatsConsoleWidth, _StatsConsoleHeight, _RootConsole, 0, _MapConsoleHeight);
        RLConsole.Blit(_MessagesConsole, 0, 0, _MessagesConsoleWidth, _MessagesConsoleHeight, _RootConsole, _StatsConsoleWidth, _MapConsoleHeight);
        _RootConsole.Draw();
    }
}
