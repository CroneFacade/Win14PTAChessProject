using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupGame setupNewGame = new SetupGame();
            setupNewGame.SetupNewGame();
            
        }
    }

    
}
