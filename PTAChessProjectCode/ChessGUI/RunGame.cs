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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Printer.PrintPieceOnBoard(engine.AIWhiteComp.PieceList);
            Console.ForegroundColor = ConsoleColor.Red;
            Printer.PrintPieceOnBoard(engine.AIBlackComp.PieceList);
        }

        public void StartGame()
        {

            bool continuePlaying = true;

            while (continuePlaying)
            {
                Console.ReadLine();
                continuePlaying = engine.InitiateWhiteTurn(continuePlaying);
                UpdateBoard();
                Console.ReadLine();
                continuePlaying = engine.InitiateBlackTurn(continuePlaying);
                UpdateBoard();
                
            }
            GameOverMenu.EnterGameOverMenu();
        }
    }
}
