using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class GameBoard
    {

        private IGame GameInterface;


        public GameBoard()
        {

            GameInterface = new IGame();
            Board = new string[8, 8];
        }

        public string[,] Board
        {
            get;

            private set;
        }

        internal void GenerateBoard(ChessPiece WPawn, ChessPiece WKing, ChessPiece BPawn, ChessPiece BKing, ChessPiece Empty)
        {
            Board[0, 4] = WKing.king;
            Board[7, 3] = BKing.king;

            for (int i = 0; i < 8; i++)
            {
                Board[1, i] = WPawn.pawn;
            }

            for (int i = 0; i < 8; i++)
            {
                Board[6, i] = BPawn.pawn;
            }

            for (int i = 2; i < 6; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Board[i, x] = Empty.empty;
                }
            }


            //Temporary
            for (int i = 0; i < 4; i++)
            {
                Board[0, i] = Empty.empty;
            }
            //Temporary
            for (int i = 5; i < 8; i++)
            {
                Board[0, i] = Empty.empty;
            }
            //Temporary
            for (int i = 0; i < 3; i++)
            {
                Board[7, i] = Empty.empty;
            }
            //Temporary
            for (int i = 4; i < 8; i++)
            {
                Board[7, i] = Empty.empty;
            }
        }


        internal void InitPrint()
        {
            var currentBoard = Board;

            GameInterface.Print(currentBoard);

        }
    }
}
