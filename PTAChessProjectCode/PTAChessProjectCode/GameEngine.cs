using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class GameEngine
    {

        internal void InitiateGame()
        {
            IGame GameInterface = new IGame();               
            List<ChessPiece> whitePieces = new List<ChessPiece>();
            
            List<ChessPiece> blackPieces = new List<ChessPiece>();
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

            Console.WriteLine(whitePieces[0].Describe());
            Console.WriteLine(whitePieces[1].Describe());
            Console.WriteLine(whitePieces[2].Describe());
            GameInterface.PrintGameBoard();
            GameInterface.PrintPieces(whitePieces, blackPieces);

            Console.ReadLine();


            /*Pawn P2 = new Pawn();
            P.PositionX = 4;
            P.PositionY = 1;
            P2.PositionX = 6;
            P2.PositionY = 8;
           
            blackPieces.Add(P2);
            P.PositionX = 5;*/

            //GameInterface.Print(whitePieces, blackPieces);
        }
    }
}
