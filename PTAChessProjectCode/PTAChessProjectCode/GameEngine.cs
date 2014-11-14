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
            countMoves = 1;
            InitiateGame();
            StartGame();
            Logger.CreateCleanLog();

        }

        // This method controls the initiatiation of the game
        public void InitiateGame()
        {
            CreateAIs();
            Printer.PrintBoard(countMoves);

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
                continuePlaying = InitiateWhiteTurn(continuePlaying);
                //Console.ReadLine();
                continuePlaying = InitiateBlackTurn(continuePlaying);
                //Console.ReadLine();
            }
        }

        private bool InitiateBlackTurn(bool continuePlaying)
        {
            if (continuePlaying == true)
            {
                continuePlaying = CheckIfGameOver(continuePlaying);
                BlackMove();
            }
            return continuePlaying;
        }

        private bool InitiateWhiteTurn(bool continuePlaying)
        {
            if (continuePlaying == true)
            {
                continuePlaying = CheckIfGameOver(continuePlaying);
                WhiteMove();
            }
            return continuePlaying;
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
            //countMoves++;
            UpdateBoard();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        private void UpdateBoard()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Printer.PrintBoard(countMoves);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Printer.PrintPieceOnBoard(AIWhiteComp.PieceList);
            Console.ForegroundColor = ConsoleColor.Blue;
            Printer.PrintPieceOnBoard(AIBlackComp.PieceList);
        }

        private bool CheckIfGameOver(bool continuePlaying)
        {

            if (AIWhiteComp.PieceList.Count == 0 || AIBlackComp.PieceList.Count == 0)
            {
                continuePlaying = false;

                //This line makes us enter a Game Over Menu
                EnterGameOverMenu();


            }
            return continuePlaying;
        }

        //Game Over Menu Method
        private static void EnterGameOverMenu()
        {
            //We want to stay in the menu until we choose
            //an menu option which is to exit the menu
            bool leaveMenu = false;
            while (!leaveMenu)
            {
                //This simply displays the Menu
                Print.GameOverMenu();
                //This collects your menu choice.
                var pressedKey = Console.ReadKey();
                //This method fetches a bool from the method and lets us know
                //if we should exit the menu or not
                leaveMenu = PerformChosenMenuOption(pressedKey, leaveMenu);
            }
            
        }

        //This method handles all of our Game Over Menu options
        public static bool PerformChosenMenuOption(ConsoleKeyInfo pressedKey, bool leaveMenu)
        {
            //If the player chose Option 1
            if (pressedKey.KeyChar == 49)
            {
                //we simply leave the manu, and the game will play again.
                leaveMenu = true;
            }
                //If we choose Option 2
            else if (pressedKey.KeyChar == 50)
            {
                //Call a method which prints out our complete move log.
                Print.PrintCompleteLog();
                //We wont leave the menu after this
                leaveMenu = false;
            }
                //If we choose option 3
            else if (pressedKey.KeyChar == 51)
            {
                //Quit the program
                Environment.Exit(404);
            }
            //Return if we should leave the menu or not
            return leaveMenu;
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
