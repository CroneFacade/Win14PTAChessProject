using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTAChessProjectCode;

namespace ChessGUI
{
    class RunGame
    {
        PrintGUI Printer;
        GameEngine engine;

        

        public RunGame(PrintGUI Printer, GameEngine engine)
        {
            this.Printer = Printer;
            this.engine = engine;
        }

        private void UpdateBoard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Printer.PrintBoard(engine.countMoves);
            Console.ForegroundColor = ConsoleColor.White;
            Printer.PrintPieceOnBoard(engine.AIWhiteComp.PieceList);
            Console.ForegroundColor = ConsoleColor.Black;
            Printer.PrintPieceOnBoard(engine.AIBlackComp.PieceList);
            Console.ResetColor();
        }

        public void StartGame()
        {

            bool continuePlaying = true;

            while (continuePlaying)
            {
                int sleeptime = 1000;
                
                //Console.ReadLine();
                continuePlaying = engine.InitiateWhiteTurn(continuePlaying);
                System.Threading.Thread.Sleep(sleeptime);
                UpdateBoard();

                //Console.ReadLine();
                
                continuePlaying = engine.InitiateBlackTurn(continuePlaying);
                System.Threading.Thread.Sleep(sleeptime);
                UpdateBoard();
                
            }
            GameOverMenu.EnterGameOverMenu();
        }
    }
}
