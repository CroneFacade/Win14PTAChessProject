using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTAChessProjectCode;

namespace ChessGUI
{

    public class PrintGUI
    {
        
        public void PrintBoard(int turnCounter)
        {
            //System.Threading.Thread.Sleep(1000);
            Console.Clear();
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
            Console.WriteLine(" ");
            Console.Write("01234567");
            Console.WriteLine("\n\nTurn: " + turnCounter);
            Console.WriteLine("Total Moves Analyzed:.... " + Logger.TotalAnalyzedMoves);
            Console.WriteLine("Total Legal Moves Found:....... " + Logger.TotalAmountOfLegalAnalyzedMoves);
            Console.WriteLine(Logger.newestLog);
        }

        public void PrintPieceOnBoard(List<ChessPiece> PieceList)
        {

            foreach (var piece in PieceList)
            {
                Console.SetCursorPosition(piece.PositionX, piece.PositionY);
                Console.WriteLine(piece.Name);
            }
            Console.SetCursorPosition(10, 10);
        }

        //This Method prints out our complete saved log
        public static void PrintCompleteLog()
        {
            Console.Clear();
            int stopCounter = 0;

            //For each individual log in our logger list
            foreach (var log in Logger.CompleteMoveLog)
            {
                //Type out that individual log
                Console.Write(log);
                //Add 1 to a counter
                stopCounter++;
                //If this counter reaches 10
                if (stopCounter == 10)
                {
                    Console.Write("Printing Paused, press any key to continue...");
                    //reset counter
                    stopCounter = 0;
                    //Pause until the user hits any key
                    Console.ReadKey();

                }
            }
            Console.Write("\n\nEnd of Log, Press any key to return to Menu");
            Console.ReadKey();
        }

        //This Method prints out the Game Over Menu
        public static void GameOverMenu()
        {
            Console.Clear();
            Console.Write("Game Over!!!!");
            Console.Write(@"
Menu:
Press the number for the chosen action
1. Play again
2. View the complete log
3. Quit game");
        }
    }


    
}
