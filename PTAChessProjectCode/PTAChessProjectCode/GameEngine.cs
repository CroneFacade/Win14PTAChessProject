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
            while (true)
            {
                /* ****************
                 Future architecture for game turns
                 
                 ClearTempList(tempList);
                 GetPlayerToMakeMove();
                 
                 FillTempListWithPieces(EmptyTempList, FriendlyPieceList);
                 FillTempListWithPieces(EmptyTempList, EnemyPieceList);
                  
                 CheckPieceThatCanMove();
                 
                 CheckPieceThatCanStrike();
                 
                 PickPieceForAction();
                 
                 ExecutePieceAction();
                 
                 CheckGameOver();
                 
                 SwitchPlayerTurn();
                 
                 ******************** */
                //var playerToMakeMove = CheckAITurn();
                AIWhiteComp.PieceList = moveData.MakeMove(AIWhiteComp, AIBlackComp.PieceList);
                countMoves++;
                Printer.PrintBoard();
                Printer.PrintPieceOnBoard(AIWhiteComp.PieceList);
                Printer.PrintPieceOnBoard(AIBlackComp.PieceList);
                AIBlackComp.PieceList = moveData.MakeMove(AIBlackComp, AIWhiteComp.PieceList);
                countMoves++;
                Printer.PrintBoard();
                Printer.PrintPieceOnBoard(AIBlackComp.PieceList);
                Printer.PrintPieceOnBoard(AIWhiteComp.PieceList);
                //SwitchAITurn(playerToMakeMove);
            }
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
