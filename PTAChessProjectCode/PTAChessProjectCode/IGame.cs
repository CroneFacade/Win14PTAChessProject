using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class IGame
    {

        internal void Print(ChessPiece[,] currentBoard)
        {
            Console.Clear();
            for (int y = 7; y >= 0; y--)
            {
                Console.Write(y+1 +" ║");
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(currentBoard[y,x].name);
                }
                Console.WriteLine();
            }
            Console.WriteLine(@"  ╚════════
—— abcdefgh");
            Console.ReadLine();
        }
    }
}
