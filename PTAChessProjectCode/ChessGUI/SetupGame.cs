using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTAChessProjectCode;

namespace ChessGUI
{
    class SetupGame
    {

        PrintGUI Printer;
        GameEngine engine;
        RunGame newGame;

        public void SetupNewGame()
        {
            InitiateNewGame();
            PrintGameBoard();
            newGame.StartGame();
        }

        private void InitiateNewGame()
        {
            engine = new GameEngine();
            Printer = new PrintGUI();
            newGame = new RunGame(Printer, engine);
            engine.InitiateGame();
        }

        private void PrintGameBoard()
        {
            Printer.PrintBoard(engine.countMoves);
            Printer.PrintPieceOnBoard(engine.AIWhiteComp.PieceList);
            Printer.PrintPieceOnBoard(engine.AIBlackComp.PieceList);
        }

        

    }  
}
