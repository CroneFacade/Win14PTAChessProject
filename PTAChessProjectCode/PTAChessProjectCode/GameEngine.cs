using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ChessGUI;


namespace PTAChessProjectCode
{
    /// <summary>
    /// Class handles the logic of the game
    /// </summary>
    public class GameEngine
    {




        //Print Printer;
        public int countMoves = 1;
        public PlayerPieces AIWhiteComp;
        public PlayerPieces AIBlackComp;
        public AIMoveData moveData;



        public GameEngine()
        {
            //printGui.PrintBoard(8);
            //printerGui = new PrintGUI();
            //Printer = new Print();
            //AIWhiteComp = new AI();
            //gui = new GUI();

        }
        public void Start()
        {
            //countMoves = 1;

            StartGame();
            Logger.CreateCleanLog();
        }

        // This method controls the initiatiation of the game
        public void InitiateGame()
        {
            CreateAIs();
            //Printer.PrintBoard(countMoves);
            //printerGui.PrintBoard(countMoves);

            //printerGui.PrintPieceOnBoard(AIWhiteComp.PieceList);
            //printerGui.PrintPieceOnBoard(AIBlackComp.PieceList);

            //Printer.PrintPieceOnBoard(AIWhiteComp.PieceList);
            //Printer.PrintPieceOnBoard(AIBlackComp.PieceList);
            SetAITurn();
            var playerToBegin = FetchAIToBegin();
            var playerNotMovin = FetchAINotMoving();
            CreateMoveLogic(playerToBegin, playerNotMovin);

        }

        public void CreateMoveLogic(PlayerPieces playerToBegin, PlayerPieces playerNotMovin)
        {
            moveData = new AIMoveData(playerToBegin, playerNotMovin);

        }

        public PlayerPieces FetchAIToBegin()
        {
            if (AIWhiteComp.MyTurn == true)
            {
                return AIWhiteComp;
            }
            else
            {
                return AIBlackComp;
            }
        }

        public PlayerPieces FetchAINotMoving()
        {
            if (AIWhiteComp.MyTurn == false)
            {
                return AIWhiteComp;
            }
            else
            {
                return AIBlackComp;
            }
        }

        public void CreateAIs()
        {
            bool playerWhite = true;
            bool playerBlack = false;
            bool myTurn = false;

            AIWhiteComp = new PlayerPieces(playerWhite, myTurn);
            AIBlackComp = new PlayerPieces(playerBlack, myTurn);

        }

        public void SetAITurn()
        {
            AIWhiteComp.MyTurn = true;
        }

        public void StartGame()
        {

            bool continuePlaying = true;

            while (continuePlaying)
            {
                // UpdateBoard();
                Console.ReadLine();
                continuePlaying = InitiateWhiteTurn(continuePlaying);
                Console.ReadLine();
                continuePlaying = InitiateBlackTurn(continuePlaying);

            }
        }

        public bool InitiateBlackTurn(bool continuePlaying)
        {
            continuePlaying = GameRules.CheckIfGameOver(continuePlaying, AIWhiteComp, AIBlackComp);
            if (continuePlaying == true)
            {
                BlackMove();
            }
            return continuePlaying;
        }

        public bool InitiateWhiteTurn(bool continuePlaying)
        {
            continuePlaying = GameRules.CheckIfGameOver(continuePlaying, AIWhiteComp, AIBlackComp);
            if (continuePlaying == true)
            {
                WhiteMove();
            }
            return continuePlaying;
        }

        private void BlackMove()
        {
            AIBlackComp.PieceList = moveData.MakeMove(AIBlackComp, AIWhiteComp.PieceList);
            countMoves++;
            //  UpdateBoard();
        }

        private void WhiteMove()
        {
            AIWhiteComp.PieceList = moveData.MakeMove(AIWhiteComp, AIBlackComp.PieceList);
            //countMoves++;
            //   UpdateBoard();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        /*private void UpdateBoard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Printer.PrintBoard(countMoves);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Printer.PrintPieceOnBoard(AIWhiteComp.PieceList);
            Console.ForegroundColor = ConsoleColor.Red;
            Printer.PrintPieceOnBoard(AIBlackComp.PieceList);
        }*/



        //Game Over Menu Method


        public PlayerPieces CheckAITurn()
        {
            if (AIWhiteComp.MyTurn == true)
            {
                return AIWhiteComp;
            }
            else
            {
                return AIBlackComp;
            }
        }

        public void SwitchAITurn(PlayerPieces playerMadeMove)
        {
            if (countMoves % 2 == 1)
            {
                AIWhiteComp.MyTurn = true;
                AIBlackComp.MyTurn = false;
            }
            else
            {
                AIBlackComp.MyTurn = true;
                AIWhiteComp.MyTurn = false;
            }

            /*if (AIWhiteComp.MyTurn == true)
            {
                AIWhiteComp.MyTurn = false;
                AIBlackComp.MyTurn = true;
                
            }
            else if (AIWhiteComp.MyTurn == false)
            {
                AIBlackComp.MyTurn = false;
                AIBlackComp.MyTurn = true;
                
            }*/
        }


        /* ********** INITIATE GAME BELOW ********************** */




        /* ################### INITATE GAME END ########################## */

        /* ********************** START GAME BELOW ************************** */


        private bool MatchCoordinate(int x, int y, int newX, int newY)
        {
            if (x == newX && y == newY)
            {
                return true;
            }
            return false;
        }
    }
}
