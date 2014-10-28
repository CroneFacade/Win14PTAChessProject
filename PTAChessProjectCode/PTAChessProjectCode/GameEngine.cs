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

            EmptyPosition Empty = new EmptyPosition(Pieces.TeamNeutral);

            King WKing = new King(Pieces.TeamWhite);

            Pawn WPawn = new Pawn(Pieces.TeamWhite);

            King BKing = new King(Pieces.TeamBlack);

            Pawn BPawn = new Pawn(Pieces.TeamBlack);

            gameBoard.GenerateBoard(WPawn, WKing, BPawn, BKing, Empty);

            gameBoard.InitPrint();


            



        }
    }
}
