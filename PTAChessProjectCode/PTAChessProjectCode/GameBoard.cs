using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class GameBoard
    {
        

        ChessPiece[,] ChessBoard = new ChessPiece[8,8];

        

        public ChessPiece[,] Board
        { 
            get; 
            
            private set; 
        }

        internal void GenerateBoard(ChessPiece WPawn, ChessPiece WKing, ChessPiece BPawn, ChessPiece BKing, ChessPiece Empty)
        {
            Board[0, 4] = WKing;
            Board[7, 3] = BKing;

            for (int i = 0; i < 8; i++)
            {
                Board[1, i] = WPawn;
            }

            for (int i = 0; i < 8; i++)
            {
                Board[6, i] = BPawn;
            }

            for (int i = 2; i < 6; i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Board[i, x] = Empty;
                }
            }


            //Temporary
            for (int i = 0; i < 4; i++)
            {
                Board[0, i] = Empty;
            }
            //Temporary
            for (int i = 5; i < 8; i++)
            {
                Board[0, i] = Empty;
            }
            //Temporary
            for (int i = 0; i < 4; i++)
            {
                Board[7, i] = Empty;
            }
            //Temporary
            for (int i = 4; i < 8; i++)
            {
                Board[7, i] = Empty;
            }
        }
    }
}
