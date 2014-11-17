using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTAChessProjectCode
{
    /// <summary>
    /// This class handles all the printing functions.
    /// </summary>
    public class Print
    {     
        public void PrintBoard(int turnCounter)
        {
            //System.Threading.Thread.Sleep(1000);
            Console.Clear();
            for (int i = 0; i < 8; i++)
            {
                ChessGUI.GUI.WriteStuffPlease("        " + '\u2502' + i);

            }
            ChessGUI.GUI.WriteStuffPlease('\u2500');
            ChessGUI.GUI.WriteStuffPlease('\u2500');
            ChessGUI.GUI.WriteStuffPlease('\u2500');
            ChessGUI.GUI.WriteStuffPlease('\u2500');
            ChessGUI.GUI.WriteStuffPlease('\u2500');
            ChessGUI.GUI.WriteStuffPlease('\u2500');
            ChessGUI.GUI.WriteStuffPlease('\u2500');
            ChessGUI.GUI.WriteStuffPlease('\u2500');
            ChessGUI.GUI.WriteStuffPlease('\u2518');
            ChessGUI.GUI.WriteNewLineStuffPlease(" ");
            ChessGUI.GUI.WriteNewLineStuffPlease("01234567");
            ChessGUI.GUI.WriteNewLineStuffPlease("\n\nTurn: " + turnCounter);
            ChessGUI.GUI.WriteNewLineStuffPlease("Total Moves Analyzed:.... " + Logger.TotalAnalyzedMoves);
            ChessGUI.GUI.WriteNewLineStuffPlease("Total Legal Moves Found:....... " + Logger.TotalAmountOfLegalAnalyzedMoves);
            ChessGUI.GUI.WriteNewLineStuffPlease(Logger.newestLog);
        }

        public void PrintPieceOnBoard(List<ChessPiece> PieceList)
        {

            foreach (var piece in PieceList)
            {
                Console.SetCursorPosition(piece.PositionX, piece.PositionY);
                ChessGUI.GUI.WriteStuffPlease(piece.Name);
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
                ChessGUI.GUI.WriteNewLineStuffPlease(log);
                //Add 1 to a counter
                stopCounter++;
                //If this counter reaches 10
                if (stopCounter == 10)
                {
                    ChessGUI.GUI.WriteNewLineStuffPlease("Printing Paused, press any key to continue...");
                    //reset counter
                    stopCounter = 0;
                    //Pause until the user hits any key
                    Console.ReadKey();

                }
            }
            ChessGUI.GUI.WriteNewLineStuffPlease("\n\nEnd of Log, Press any key to return to Menu");
            Console.ReadKey();
        }

        //This Method prints out the Game Over Menu
        public static void GameOverMenu()
        {
            Console.Clear();
            ChessGUI.GUI.WriteNewLineStuffPlease("Game Over!!!!");
            ChessGUI.GUI.WriteNewLineStuffPlease(@"
Menu:
Press the number for the chosen action
1. Play again
2. View the complete log
3. Quit game");
        }
    }
}
