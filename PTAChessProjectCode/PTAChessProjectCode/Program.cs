using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode                   //Andreas Push: https://ekwall@github.com/Win14Crone/PTAChessProject 
                                                //Therese Push: https://Win14Therese@github.com/Win14Crone/PTAChessProject
{
    class Program
    {
        static void Main(string[] args)
        {

            GameBoard gameBoard = new GameBoard();
            ChessPiece Pieces = new ChessPiece();
            //Chess Game Starts here
            ChessPiece Empty = new ChessPiece(Pieces.TeamNeutral, Pieces.empty);

            ChessPiece WKing = new ChessPiece(Pieces.TeamWhite, Pieces.king);

            ChessPiece WPawn = new ChessPiece(Pieces.TeamWhite, Pieces.pawn);

            /*
            ChessPiece WPawn2 = new ChessPiece(Pieces.TeamWhite, Pieces.pawn);
            ChessPiece WPawn3 = new ChessPiece(Pieces.TeamWhite, Pieces.pawn);
            ChessPiece WPawn4 = new ChessPiece(Pieces.TeamWhite, Pieces.pawn);
            ChessPiece WPawn5 = new ChessPiece(Pieces.TeamWhite, Pieces.pawn);
            ChessPiece WPawn6 = new ChessPiece(Pieces.TeamWhite, Pieces.pawn);
            ChessPiece WPawn7 = new ChessPiece(Pieces.TeamWhite, Pieces.pawn);
            ChessPiece WPawn8 = new ChessPiece(Pieces.TeamWhite, Pieces.pawn);

             */ 
             
            ChessPiece BKing = new ChessPiece(Pieces.TeamBlack, Pieces.king);

            ChessPiece BPawn = new ChessPiece(Pieces.TeamBlack, Pieces.pawn);

            /*
            ChessPiece BPawn2 = new ChessPiece(Pieces.TeamBlack, Pieces.pawn);
            ChessPiece BPawn3 = new ChessPiece(Pieces.TeamBlack, Pieces.pawn);
            ChessPiece BPawn4 = new ChessPiece(Pieces.TeamBlack, Pieces.pawn);
            ChessPiece BPawn5 = new ChessPiece(Pieces.TeamBlack, Pieces.pawn);
            ChessPiece BPawn6 = new ChessPiece(Pieces.TeamBlack, Pieces.pawn);
            ChessPiece BPawn7 = new ChessPiece(Pieces.TeamBlack, Pieces.pawn);
            ChessPiece BPawn8 = new ChessPiece(Pieces.TeamBlack, Pieces.pawn);

             */ 
             
            gameBoard.GenerateBoard(WPawn, WKing, BPawn, BKing, Empty);
        }
    }
}
