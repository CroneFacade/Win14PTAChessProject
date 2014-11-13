using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PTAChessProjectCode
{
    public class GameEngine
    {

        Print Printer;
        public int countMoves = 1;
        public AI AIWhiteComp;
        public AI AIBlackComp;
        public MoveData moveData;

        public GameEngine()
        {
            Printer = new Print();
            //AIWhiteComp = new AI();
            //gui = new GUI();

        }
        public void Start()
        {
            InitiateGame();
            StartGame();
        }

        // This method controls the initiatiation of the game
        public void InitiateGame()
        {
            CreateAIs();
            Printer.PrintBoard();

            Printer.PrintPieceOnBoard(AIWhiteComp.PieceList);
            Printer.PrintPieceOnBoard(AIBlackComp.PieceList);
            SetAITurn();
            var playerToBegin = FetchAIToBegin();
            var playerNotMovin = FetchAINotMoving();
            CreateMoveLogic(playerToBegin, playerNotMovin);

        }

        public void CreateMoveLogic(AI playerToBegin, AI playerNotMovin)
        {
            moveData = new MoveData(playerToBegin, playerNotMovin);

        }

        public AI FetchAIToBegin()
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

        public AI FetchAINotMoving()
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

            AIWhiteComp = new AI(playerWhite, myTurn);
            AIBlackComp = new AI(playerBlack, myTurn);

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

                continuePlaying = CheckIfGameOver(continuePlaying);

                WhiteMove();

                continuePlaying = CheckIfGameOver(continuePlaying);

                BlackMove();
            }
        }

        private void BlackMove()
        {
            AIBlackComp.PieceList = moveData.MakeMove(AIBlackComp, AIWhiteComp.PieceList);
            countMoves++;
            UpdateBoard();
        }

        private void WhiteMove()
        {
            AIWhiteComp.PieceList = moveData.MakeMove(AIWhiteComp, AIBlackComp.PieceList);
            countMoves++;
            UpdateBoard();
        }

        private void UpdateBoard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Printer.PrintBoard();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Printer.PrintPieceOnBoard(AIWhiteComp.PieceList);
            Console.ForegroundColor = ConsoleColor.Blue;
            Printer.PrintPieceOnBoard(AIBlackComp.PieceList);
        }

        private bool CheckIfGameOver(bool continuePlaying)
        {
            if (AIWhiteComp.PieceList.Count == 0 || AIBlackComp.PieceList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Game Over!!!!");
                Console.WriteLine("Press any key to play again or q to quit.");
                var pressedKey = Console.ReadKey();

                if (pressedKey.KeyChar == 113)
                {
                    Environment.Exit(404);
                }
                else
                {
                    continuePlaying = false;

                }


            }
            return continuePlaying;
        }

        

        public AI CheckAITurn()
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

        public void SwitchAITurn(AI playerMadeMove)
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
