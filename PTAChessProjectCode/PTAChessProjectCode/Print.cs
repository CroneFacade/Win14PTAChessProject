using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTAChessProjectCode
{ 
    public class Print
       
    {     //This class handles all the printing functions.
        public void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("        " + '\u2502' + i);

            }
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2518');
            Console.WriteLine();
            Console.WriteLine("01234567");
        }

        public void PrintPieceOnBoard(List<ChessPiece> PieceList)
        {

            foreach (var piece in PieceList)
            {
                Console.SetCursorPosition(piece.PositionX, piece.PositionY);
                Console.Write(piece.Name);
            }
            Console.SetCursorPosition(10, 10);
        }
    }
}
