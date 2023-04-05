using OpenTK.Platform.Windows;
using RLNET;
using System;
using ConsoleDog.Map;
using System.Reflection.Emit;
using System.Collections.Generic;
using ConsoleDog.System;
using ConsoleDog.Actor;
using MessageLog;

public class Program
{
    public static Random Rand = new Random();
    public static Player Player { get; private set; }
    public static Map Map { get; set; }
    private static bool _RenderRequired = true;
    public static ComandSystem ComandSystem { get; private set; }
    public static MessageLog.MessageLog MessageLog { get; private set; }

    private static RLConsole _MapConsole;
    static readonly int _MapConsoleWidth = 85;
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

    public static void Main(string[] args)
    {
        MessageLog = new MessageLog.MessageLog();
        MessageLog.Add("The rogue arrives on level 1");

        Player = new Player();

        ComandSystem = new ComandSystem();

        string fontFileName = "ascii_8x8.png";
        string ConsoleTitle = "ConsoleDog";
        
        _RootConsole = new RLRootConsole(fontFileName, _RootConsoleWidth, _RootConsoleHeight, 8, 8, 2f, ConsoleTitle);
        _MapConsole = new RLConsole(_RootConsoleWidth, _RootConsoleHeight);
        _StatsConsole = new RLConsole(_StatsConsoleWidth, _StatsConsoleHeight);
        _MessagesConsole = new RLConsole(_MessagesConsoleWidth, _MessagesConsoleHeight);
        
        Map.MapCreation(Rand);
        

        _RootConsole.Update += OnRootConsoleUpdate;
        _RootConsole.Render += OnRootConsoleRender;
        _RootConsole.Run();
    }
    static void OnRootConsoleUpdate(object sender, EventArgs e) // Логика 
    {
        bool didPlayerAct = false;
        RLKeyPress keyPress = _RootConsole.Keyboard.GetKeyPress();
        if (keyPress != null)
        {
            switch (keyPress.Key)
            {
                case RLKey.Up:
                    didPlayerAct = ComandSystem.MovePlayer(ConsoleDog.Core.Direction.Up);
                    break;

                case RLKey.Down:
                    didPlayerAct = ComandSystem.MovePlayer(ConsoleDog.Core.Direction.Down);
                    break;

                case RLKey.Left:
                    didPlayerAct = ComandSystem.MovePlayer(ConsoleDog.Core.Direction.Left);
                    break;
                case RLKey.Right:
                    didPlayerAct = ComandSystem.MovePlayer(ConsoleDog.Core.Direction.Right);
                    break;
                case RLKey.Escape:
                    _RootConsole.Close();
                    break;
                default:
                    break;
            }
            if (didPlayerAct)
            {
                _RenderRequired = true;
            }
        }
    }
    static void OnRootConsoleRender(object sender, EventArgs e) //Прорисовка
    {
        if (_RenderRequired)
        {
            _RootConsole.Clear();
            _MapConsole.SetBackColor(0, 0, _MapConsoleWidth, _MapConsoleHeight, RLColor.Black);
            Map.Draw(_MapConsole);
            Player.Draw(_MapConsole);

            RLConsole.Blit(_MapConsole, 0, 0, _MapConsoleWidth, _MapConsoleHeight, _RootConsole, 0, 0);

            RLConsole.Blit(_StatsConsole, 0, 0, _StatsConsoleWidth, _StatsConsoleHeight, _RootConsole, 0, _MapConsoleHeight);
            Player.DrawStats(_StatsConsole);

            RLConsole.Blit(_MessagesConsole, 0, 0, _MessagesConsoleWidth, _MessagesConsoleHeight, _RootConsole, _StatsConsoleWidth, _MapConsoleHeight);
            MessageLog.Draw(_MessagesConsole);

            _RootConsole.Draw();

            _RenderRequired = false;
        }
    }
}
