using ConsoleDog.Map;
using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDog.Interface
{
    public interface IDrowable
    {
        RLColor Color { get; set; }
        char Symbol { get; set; }
        int X { get; set; }
        int Y { get; set; }
        
        
        void Draw(RLConsole console); //Класс IMAP в github 
    }
}
