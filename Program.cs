using OpenTK.Platform.Windows;
using RLNET;
using System;
//using ConsoleDog.HaracterandPersons;
using ConsoleDog.Map;
//using ConsoleDog.PlayerAndPerson;
using ConsoleDog.Person;
using System.Reflection.Emit;

public class Program
{
    private static Player Hero = new Player("Evgeny", 1, 1, 1, 1, 1, 1, 4, 4, '@');
    static Enemy enemy = Enemy_Factory.CreateEnemy(1);
    private static RLConsole _MapConsole;
    static readonly int _MapConsoleWidth = ConsoleDogMap._MapWidth;
    static readonly int _MapConsoleHeight = ConsoleDogMap._MapHeight;
    private static RLConsole _StatsConsole;
    private static readonly int _StatsConsoleWidth = 13;
    private static readonly int _StatsConsoleHeight = 13;
    private static RLConsole _MessagesConsole;
    private static readonly int _MessagesConsoleWidth = _MapConsoleWidth - _StatsConsoleWidth;
    private static readonly int _MessagesConsoleHeight = _StatsConsoleHeight;
    private static RLRootConsole _RootConsole;
    static readonly int _RootConsoleWidth = _MapConsoleWidth;
    static readonly int _RootConsoleHeight = _MapConsoleHeight + _StatsConsoleHeight;

    public static void Main(string[] args)
    {
        Random Rand = new Random();
        ConsoleDogMap.MapCreation(Rand);
        string fontFileName = "ascii_8x8.png";
        string ConsoleTitle = "ConsoleDog";
        _RootConsole = new RLRootConsole(fontFileName, _RootConsoleWidth, _RootConsoleHeight, 8, 8, 2f, ConsoleTitle);
        _MapConsole = new RLConsole(_RootConsoleWidth, _RootConsoleHeight);
        _StatsConsole = new RLConsole(_StatsConsoleWidth, _StatsConsoleHeight);
        _MessagesConsole = new RLConsole(_MessagesConsoleWidth, _MessagesConsoleHeight);
        _RootConsole.Update += OnRootConsoleUpdate;
        _RootConsole.Render += OnRootConsoleRender;
        _RootConsole.Run();
    }
    static void OnRootConsoleUpdate(object sender, EventArgs e) // Логика 
    {
        RLKeyPress keyPress = _RootConsole.Keyboard.GetKeyPress();
        if (keyPress != null)
        {
            int x = Hero._PlayerX;
            int y = Hero._PlayerY;
            switch (keyPress.Key)
            {
                case RLKey.Up:
                    if (ConsoleDogMap._Cells[y - 1, x]._IsWalkable == true)
                    {
                        --Hero._PlayerY;
                    }
                    break;

                case RLKey.Down:
                    if (ConsoleDogMap._Cells[y + 1, x]._IsWalkable == true)
                    {
                        ++Hero._PlayerY;
                    }
                    break;

                case RLKey.Left:
                    if (ConsoleDogMap._Cells[y, x - 1]._IsWalkable == true)
                    {
                        --Hero._PlayerX;
                    }
                    break;
                case RLKey.Right:
                    if (ConsoleDogMap._Cells[y, x + 1]._IsWalkable == true)
                    {
                        ++Hero._PlayerX;
                    }
                    break;
            }
        }
    }
    static void OnRootConsoleRender(object sender, EventArgs e) //Прорисовка
    {
        _RootConsole.Clear();
        _MapConsole.SetBackColor(0, 0, _MapConsoleWidth, _MapConsoleHeight, RLColor.Black);

        for (int y = 0; y < ConsoleDogMap._MapHeight; y++)
        {
            for (int x = 0; x < ConsoleDogMap._MapWidth; x++)
            {
                if (ConsoleDogMap._Cells[y, x]._IsMap == true)
                {
                    if (ConsoleDogMap._Cells[y, x]._IsWalkable == true)
                    {
                        _MapConsole.Set(x, y, RLColor.Gray, null, '.');
                    }
                    else
                    {
                        _MapConsole.Set(x, y, RLColor.White, null, '#'); // Отрисовка карты
                    }
                }

            }
        }
        _MapConsole.Set(Hero._PlayerX, Hero._PlayerY, RLColor.White, null, Hero._Icon);
        _MapConsole.Set(enemy._PlayerX, enemy._PlayerY, RLColor.White, null, enemy._Icon);




        RLConsole.Blit(_MapConsole, 0, 0, _MapConsoleWidth, _MapConsoleHeight, _RootConsole, 0, 0);

        RLConsole.Blit(_StatsConsole, 0, 0, _StatsConsoleWidth, _StatsConsoleHeight, _RootConsole, 0, _MapConsoleHeight);
        _StatsConsole.SetBackColor(0, 0, _StatsConsoleWidth, _StatsConsoleHeight, RLColor.Brown);
        _StatsConsole.Print(3, 1, "STATS", RLColor.White);

        RLConsole.Blit(_MessagesConsole, 0, 0, _MessagesConsoleWidth, _MessagesConsoleHeight, _RootConsole, _StatsConsoleWidth, _MapConsoleHeight);
        _MessagesConsole.SetBackColor(0, 0, _MessagesConsoleWidth, _MessagesConsoleHeight, RLColor.Blue);
        _MessagesConsole.Print(1, 1, "MESSAGES", RLColor.White);
        _MessagesConsole.Print(1, 3, $"({Hero._PlayerX};{Hero._PlayerY})", RLColor.White);
        _RootConsole.Draw();
    }
}
