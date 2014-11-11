using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PTAChessProjectCode
{
    class GameEngine
    {

        //GUI gui;
        public int countMoves = 1;
        public AI AIWhiteComp;
        public AI AIBlackComp;
        public MoveData moveData;

        public GameEngine()
        {
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
            PrintBoard();
            PrintPieceOnBoard(AIWhiteComp.PieceList);
            PrintPieceOnBoard(AIBlackComp.PieceList);
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
                var playerToMakeMove = CheckAITurn();
                moveData.MakeMove(playerToMakeMove);
                countMoves++;
                SwitchAITurn(playerToMakeMove);
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

        public void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("        " + '\u2502' + i);

            }
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2500');
            Console.Write('\u2518');
            Console.WriteLine();
            Console.WriteLine("01234567");
        }

        public void PrintPieceOnBoard(List<ChessPiece> PieceList)
        {

            foreach (var piece in PieceList)
            {
                Console.SetCursorPosition(piece.PositionX, piece.PositionY);
                Console.Write(piece.Name);
            }
            Console.SetCursorPosition(10, 10);
        }


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
