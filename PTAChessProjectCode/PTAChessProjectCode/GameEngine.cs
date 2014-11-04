using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    /// <summary>
    /// GameEngine contains logic about how the game calculates things.
    /// </summary>
    class GameEngine
    {

        public List<ChessPiece> whitePieces { get; set; }
        public List<ChessPiece> blackPieces { get; set; }
        Print PrintGame;


        

        // Construct that declare the instance GameInterface of class IGame. 
        // Note that the instance is not initialized yet, only declared that we will use it later on.
        public GameEngine()
        {
            PrintGame = new Print();

        }

        // Bröt ut slumpfunktionen ur jättemetoden StartGame() och gjorde en egen metod av den. 
        // Mest för att visa hur man kan bryta ut beräkningar och på så vis få små smidiga metoder
        // vilka i slutändan har 1 syfte.



        internal void StartGame()
        {
            //#########################################################################
            //Something like this is how we want it to be in the future
            
                        bool whiteLost = false;
                        bool blackLost = false;

                        AI WhiteCleverComputer = new AI(whitePieces, blackPieces);
                        AI BlackCleverComputer = new AI(blackPieces, whitePieces);

                        while (!whiteLost && !blackLost)
                        {
                            WhiteCleverComputer.UpdatePieces(whitePieces, blackPieces);

                            WhiteCleverComputer.InitTurn(-1); //This int we send in tells the AI which direction is forwards

                            whitePieces = WhiteCleverComputer.GetMyPieces();

                            blackPieces = WhiteCleverComputer.GetEnemyPieces();

                            blackLost = WhiteCleverComputer.DidEnemyTeamLose();

                            PrintGame.PrintGameBoard();
                            PrintGame.PrintPieces(whitePieces, blackPieces);

                            if (!blackLost)
                            {
                                BlackCleverComputer.UpdatePieces(blackPieces, whitePieces);

                                BlackCleverComputer.InitTurn(+1); //This int we send in tells the AI which direction is forwards

                                blackPieces = BlackCleverComputer.GetMyPieces();

                                whitePieces = BlackCleverComputer.GetEnemyPieces();

                                whiteLost = BlackCleverComputer.DidEnemyTeamLose();

                                PrintGame.PrintGameBoard();
                                PrintGame.PrintPieces(whitePieces, blackPieces);
                            }
                        }
            
            //##########################################################################
            //Everything below this line in StartGame() is just here temporarily
            //This will all be in AI later
            // Random rnd = new Random();
           
            
            
           /* 
           while (true)
            {
                // Generate a random number depending on a min and max value. Maxvalue is the list.Count

                bool whiteHasMoved = false;
                while (!whiteHasMoved)
                {

                    GenerateRandomNumber(0, whitePieces);

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

                    if (whiteHasMoved == false && whitePieces[randomNumber].PositionY > 0)
                    {
                        MovePiece(whitePieces[randomNumber], whitePieces[randomNumber].PositionX, whitePieces[randomNumber].PositionY - 1);
                        whiteHasMoved = true;
                    }
                    
                }

                // Generate a random number depending on a min and max value. Maxvalue is the list.Count
                GenerateRandomNumber(0, blackPieces);

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
                whiteHasMoved = true;*/
            }
         /* ***  internal void StartGame() end *** */

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
            PrintGame.PrintGameBoard();
            PrintGame.PrintPieces(whitePieces, blackPieces);

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
            PrintGame.PrintPieces(whitePieces, blackPieces);
            //Console.SetCursorPosition(piece.PositionX, piece.PositionY);
            //Console.Write(piece.Name);

        } /* *** internal void InitiateGame() End *** */
    }
}
