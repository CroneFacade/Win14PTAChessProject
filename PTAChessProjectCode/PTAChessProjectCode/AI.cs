using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    public class AI
    {
        public List<ChessPiece> PieceList { get; set; }
        public bool IsWhite { get; set; }
        public bool MyTurn { get; set; }
        public AI(bool isWhite, bool myTurn)
        {
            CheckTeamToMakePiecesFor(isWhite, myTurn);
        }

        private void CheckTeamToMakePiecesFor(bool isWhite, bool myTurn)
        {
            this.IsWhite = isWhite;
            this.MyTurn = myTurn;

            PieceList = new List<ChessPiece>();

            if (IsWhite)
            {
                AddPieces(-1);
            }
            else
            {
                AddPieces(1);
            }
        }

        public void AddPieces(int teamdirection)
        {
            int gameBoardWidth = 8;

            GeneratePieces(teamdirection, gameBoardWidth);

            GeneratePositionsForPieces(teamdirection, gameBoardWidth);
        }

        private void GeneratePieces(int teamdirection, int gameBoardWidth)
        {
            Rook rook = new Rook();

            Knight knight = new Knight();

            Bishop bishop = new Bishop();

            King king = new King();

            Queen queen = new Queen();

            Bishop bishop2 = new Bishop();

            Knight knight2 = new Knight();

            Rook rook2 = new Rook();

            PieceList.Add(rook);
            PieceList.Add(knight);
            PieceList.Add(bishop);
            if (teamdirection == 1)
                PieceList.Add(king);
            PieceList.Add(queen);
            if (teamdirection == -1)
                PieceList.Add(king);
            PieceList.Add(bishop2);
            PieceList.Add(knight2);
            PieceList.Add(rook2);

            for (int i = 0; i < gameBoardWidth; i++)
            {
                Pawn pawn = new Pawn();
                PieceList.Add(pawn);
            }
        }

        private void GeneratePositionsForPieces(int teamdirection, int gameBoardWidth)
        {
            int x = 0;
            int y = 0;
            int ID = 0;

            if (teamdirection == -1)
            {
                x = 0;
                y = 7;
            }

            foreach (var piece in PieceList)
            {
                piece.PositionX = x;
                piece.PositionY = y;
                piece.id = ID;
                piece.teamDirection = teamdirection;
                x++;
                ID++;
                if (x == gameBoardWidth)
                {
                    x = 0;
                    y = y + teamdirection;
                }
            }
        }
    }
}
