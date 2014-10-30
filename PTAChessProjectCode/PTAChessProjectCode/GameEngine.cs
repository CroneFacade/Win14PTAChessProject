using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class GameEngine
    {
        private GameBoard gameBoard;
        private ChessPiece Pieces;
        

        public GameEngine()
        {
            gameBoard = new GameBoard();
            Pieces = new ChessPiece();
            
        }

        internal void InitiateGame()
        {
            //Chess Game Starts here

            AI AIWhite = new AI();
            AI AIBlack = new AI();

            EmptyPosition Empty = new EmptyPosition(Pieces.TeamNeutral);

            Empty.name = Empty.empty;

            King WKing = new King(Pieces.TeamWhite);

            WKing.name = WKing.king;

            Pawn WPawn = new Pawn(Pieces.TeamWhite);

            WPawn.name = WPawn.pawn;

            King BKing = new King(Pieces.TeamBlack);

            BKing.name = BKing.king;

            Pawn BPawn = new Pawn(Pieces.TeamBlack);

            BPawn.name = BPawn.pawn;

            gameBoard.GenerateBoard(WPawn, WKing, BPawn, BKing, Empty);

            gameBoard.InitPrint();

            gameBoard.MovePiece(1, 4, 2, 4);

            gameBoard.InitPrint();

            //AIWhite.CollectBoardInfo(gameBoard.Board);

            


            



        }
    }
}
