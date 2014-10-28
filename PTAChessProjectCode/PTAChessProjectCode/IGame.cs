using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class IGame
    {

        internal void Print(string[,] currentBoard)
        {
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(currentBoard[y,x]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
