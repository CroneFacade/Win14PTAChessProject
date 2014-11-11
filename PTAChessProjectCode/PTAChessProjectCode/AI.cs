using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class AI
    {
        public List<ChessPiece> PieceList { get; set; }
        public bool IsWhite { get; set; }
        public bool MyTurn { get; set; }
        public AI(bool isWhite, bool myTurn)
        {
            this.IsWhite = isWhite;
            this.MyTurn = myTurn;

            PieceList = new List<ChessPiece>();

            if (IsWhite)
            {
                AddWhitePiece("0,-1.1");
            }
            else
            {
                AddBlackPiece("0,1.1");
            }
            
        }
        // Försök till att i en metod skapa nya pjäser.
        //public void CreateChessPiece(int x, int y, ChessPiece piece)
        //{
        //    piece = new Pawn(x, y);
        //    piece.id = 1;
        //    PieceList.Add(piece);
        //}
        public void CreateChessPiece(int x, int y, Rook rook)
        {

        }
        public void AddPieceToList(ChessPiece PiecetoAdd)
        {
            PieceList.Add(PiecetoAdd);
        }
        public void AddWhitePiece(string movement)
        {
            Pawn pawn = new Pawn();
            pawn.id = 1;
            PieceList.Add(pawn);

            Pawn pawn2 = new Pawn();
            pawn.id = 2;
            PieceList.Add(pawn2);

            Pawn pawn3 = new Pawn();
            pawn.id = 3;
            PieceList.Add(pawn3);

            Pawn pawn4 = new Pawn();
            pawn.id = 4;
            PieceList.Add(pawn4);

            Pawn pawn5 = new Pawn();
            pawn.id = 5;
            PieceList.Add(pawn5);

            Pawn pawn6 = new Pawn();
            pawn.id = 6;
            PieceList.Add(pawn6);

            Pawn pawn7 = new Pawn();
            pawn.id = 7;
            PieceList.Add(pawn7);

            Pawn pawn8 = new Pawn();
            pawn.id = 8;
            PieceList.Add(pawn8);

            Rook rook = new Rook();
            rook.id = 1;
            PieceList.Add(rook);

            Rook rook2 = new Rook();
            rook.id = 2;
            PieceList.Add(rook2);

            Knight knight = new Knight();
            knight.id = 1;
            PieceList.Add(knight);

            Knight knight2 = new Knight();
            knight.id = 2;
            PieceList.Add(knight2);

            Bishop bishop = new Bishop();
            bishop.id = 1;
            PieceList.Add(bishop);

            Bishop bishop1 = new Bishop();
            bishop1.id = 2;
            PieceList.Add(bishop1);

            King king = new King();
            PieceList.Add(king);

            Queen queen = new Queen();
            PieceList.Add(queen);

        }

        public void AddBlackPiece(string movement)
        {
            Pawn pawn = new Pawn();
            pawn.id = 1;
            PieceList.Add(pawn);

            Pawn pawn2 = new Pawn();
            pawn.id = 2;
            PieceList.Add(pawn2);

            Pawn pawn3 = new Pawn();
            pawn.id = 3;
            PieceList.Add(pawn3);

            Pawn pawn4 = new Pawn();
            pawn.id = 4;
            PieceList.Add(pawn4);

            Pawn pawn5 = new Pawn();
            pawn.id = 5;
            PieceList.Add(pawn5);

            Pawn pawn6 = new Pawn();
            pawn.id = 6;
            PieceList.Add(pawn6);

            Pawn pawn7 = new Pawn();
            pawn.id = 7;
            PieceList.Add(pawn7);

            Pawn pawn8 = new Pawn();
            pawn.id = 8;
            PieceList.Add(pawn8);

            Rook rook = new Rook();
            rook.id = 1;
            PieceList.Add(rook);

            Rook rook2 = new Rook();
            rook.id = 2;
            PieceList.Add(rook2);

            Knight knight = new Knight();
            knight.id = 1;
            PieceList.Add(knight);

            Knight knight2 = new Knight();
            knight.id = 2;
            PieceList.Add(knight2);

            Bishop bishop = new Bishop();
            bishop.id = 1;
            PieceList.Add(bishop);

            Bishop bishop1 = new Bishop();
            bishop1.id = 2;
            PieceList.Add(bishop1);

            King king = new King();
            PieceList.Add(king);

            Queen queen = new Queen();
            PieceList.Add(queen);

        }
    }
}
