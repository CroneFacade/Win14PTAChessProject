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

        public void InitiateGame()
        {
            CreateAIs();
            CreateMoveLogic(AIWhiteComp, AIBlackComp);
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

        public void CreateMoveLogic(PlayerPieces AIWhiteComp, PlayerPieces AIBlackComp)
        {
            moveData = new AIMoveData(AIWhiteComp, AIBlackComp);

        }

        /* ####### iniate new game end ####### */

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
            Console.ForegroundColor = ConsoleColor.White;
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