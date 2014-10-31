using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class GameEngine
    {

        public List<ChessPiece> whitePieces { get; set; }
        public List<ChessPiece> blackPieces { get; set; }
        IGame GameInterface;

        public GameEngine()
        {
            GameInterface = new IGame();
        }
        internal void StartGame()
        {
            Random rnd = new Random();
            while (true)
            {
                int max = whitePieces.Count;
                int min = 0;

                int randomNumber = rnd.Next(min, max);
                bool whiteHasMoved = false;


                foreach (var piece in blackPieces)
                {
                    if (piece.PositionX == whitePieces[randomNumber].PositionX - 1 && piece.PositionY == whitePieces[randomNumber].PositionY - 1)
                    {
                        RemovePiece(blackPieces, whitePieces[randomNumber].PositionX - 1, whitePieces[randomNumber].PositionY - 1);
                        MovePiece(whitePieces[randomNumber], whitePieces[randomNumber].PositionX - 1, whitePieces[randomNumber].PositionY - 1);
                        whiteHasMoved = true;
                        break;
                    }
                    if (piece.PositionX == whitePieces[randomNumber].PositionX + 1 && piece.PositionY == whitePieces[randomNumber].PositionY - 1)
                    {
                        RemovePiece(blackPieces, whitePieces[randomNumber].PositionX + 1, whitePieces[randomNumber].PositionY - 1);
                        MovePiece(whitePieces[randomNumber], whitePieces[randomNumber].PositionX + 1, whitePieces[randomNumber].PositionY - 1);
                        whiteHasMoved = true;
                        break;
                    }
                }

                if (whiteHasMoved == false)
                {
                    MovePiece(whitePieces[randomNumber], whitePieces[randomNumber].PositionX, whitePieces[randomNumber].PositionY - 1);
                }
                whiteHasMoved = true;
                max = blackPieces.Count;
                min = 0;

                randomNumber = rnd.Next(min, max);

                bool blackHasMoved = false;


                foreach (var piece in whitePieces)
                {
                    if (piece.PositionX == blackPieces[randomNumber].PositionX - 1 && piece.PositionY == blackPieces[randomNumber].PositionY + 1)
                    {
                        RemovePiece(whitePieces, blackPieces[randomNumber].PositionX - 1, blackPieces[randomNumber].PositionY + 1);
                        MovePiece(blackPieces[randomNumber], blackPieces[randomNumber].PositionX - 1, blackPieces[randomNumber].PositionY + 1);
                        blackHasMoved = true;
                        break;
                    }
                    if (piece.PositionX == blackPieces[randomNumber].PositionX + 1 && piece.PositionY == blackPieces[randomNumber].PositionY + 1)
                    {
                        RemovePiece(whitePieces, blackPieces[randomNumber].PositionX + 1, blackPieces[randomNumber].PositionY + 1);
                        MovePiece(blackPieces[randomNumber], blackPieces[randomNumber].PositionX + 1, blackPieces[randomNumber].PositionY + 1);
                        blackHasMoved = true;
                        break;
                    }
                }

                if (blackHasMoved == false)
                {
                    MovePiece(blackPieces[randomNumber], blackPieces[randomNumber].PositionX, blackPieces[randomNumber].PositionY + 1);
                }
                whiteHasMoved = true;

                MovePiece(blackPieces[randomNumber], blackPieces[randomNumber].PositionX, blackPieces[randomNumber].PositionY + 1);



            }


            /*
            MovePiece(whitePieces[4], 7, 5);
            
            MovePiece(blackPieces[3], 6, 2);
            
            MovePiece(whitePieces[4], 7, 4);
            
            MovePiece(blackPieces[3], 6, 3);
            
            RemovePiece(blackPieces, 6, 3);
            
            MovePiece(whitePieces[4], 6, 3);
            
            MovePiece(blackPieces[4], 8, 3);
            
            MovePiece(whitePieces[4], 6, 2);

            RemovePiece(whitePieces, 6, 2);

            MovePiece(blackPieces[3], 6, 2);

            MovePiece(whitePieces[4], 8, 5);

            MovePiece(blackPieces[3], 6, 3);

            MovePiece(whitePieces[4], 8, 4);

            MovePiece(blackPieces[3], 6, 4);

            MovePiece(whitePieces[2], 5, 5);

            RemovePiece(whitePieces, 5, 5);

            MovePiece(blackPieces[3], 5, 5);

            RemovePiece(blackPieces, 5, 5);

            MovePiece(whitePieces[1], 5, 5);

            MovePiece(blackPieces[5], blackPieces[5].PositionX, blackPieces[5].PositionY +1);

            MovePiece(whitePieces[2], 6, 6);

            MovePiece(blackPieces[5], blackPieces[5].PositionX, blackPieces[5].PositionY + 1);

             
             */
        }
        internal void InitiateGame()
        {
            whitePieces = new List<ChessPiece>();
            blackPieces = new List<ChessPiece>();

            for (int i = 3; i < 11; i++)
            {
                Pawn P = new Pawn();
                P.ID = i;
                P.PositionX = i;
                P.PositionY = 6;
                P.Name = "P";
                whitePieces.Add(P);
            }
            for (int i = 3; i < 11; i++)
            {
                Pawn P = new Pawn();
                P.ID = i;
                P.PositionX = i;
                P.PositionY = 1;
                P.Name = "P";
                blackPieces.Add(P);
            }
            GameInterface.PrintGameBoard();
            GameInterface.PrintPieces(whitePieces, blackPieces);

            StartGame();
            //whitePieces = RemovePiece(whitePieces, 2, 2);

            //MovePiece(whitePieces[0], whitePieces[0].PositionX + 1, whitePieces[0].PositionY);
            /*
            
            
            //blackPieces = RemovePiece(blackPieces, 3, 6);
            Console.ReadKey();
            */
            // GameInterface.PrintPieces(whitePieces, blackPieces);
        }
        public List<ChessPiece> RemovePiece(List<ChessPiece> pieceList, int x, int y)
        {
            foreach (var piece in pieceList)
            {
                if (piece.PositionX == x && piece.PositionY == y)
                {
                    pieceList.Remove(piece);
                    break;
                }
            }
            return pieceList;
        }
        public void MovePiece(ChessPiece piece, int x, int y)
        {
            //MovePiece(whitePieces[0], whitePieces[0].PositionX, whitePieces[0].PositionY + 1);

            Console.SetCursorPosition(piece.PositionX, piece.PositionY);
            Console.Write(" ");
            piece.PositionX = x;
            piece.PositionY = y;
            GameInterface.PrintPieces(whitePieces, blackPieces);
            //Console.SetCursorPosition(piece.PositionX, piece.PositionY);
            //Console.Write(piece.Name);
        }
    }
}
