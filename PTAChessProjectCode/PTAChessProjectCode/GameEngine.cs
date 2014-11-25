using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PTAChessProjectCode
{
    /// <summary>
    /// Handles all the logic of the chessgame
    /// </summary>
    public class GameEngine
    {

        public int countMoves = 1;
        public PlayerPieces AIWhiteComp;
        public PlayerPieces AIBlackComp;
        public AIMoveData moveData;

        public void Start()
        {
            StartGame();
            Logger.CreateCleanLog();
        }

        public void InitiateGame()
        {
            CreateAIs();
            SetAITurn();
            var playerToBegin = FetchAIToBegin();
            var playerNotMovin = FetchAINotMoving();
            CreateMoveLogic(playerToBegin, playerNotMovin);
        }

        /* ***** Initiate new game ******* */

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

        public void CreateMoveLogic(PlayerPieces playerToBegin, PlayerPieces playerNotMovin)
        {
            moveData = new AIMoveData(playerToBegin, playerNotMovin);

        }

        /* ####### iniate new game end ####### */

        public void StartGame()
        {
            bool continuePlaying = true;

            while (continuePlaying)
            {
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
        }

        private void WhiteMove()
        {
            AIWhiteComp.PieceList = moveData.MakeMove(AIWhiteComp, AIBlackComp.PieceList);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

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
        }

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