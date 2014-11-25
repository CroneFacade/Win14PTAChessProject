using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class GameRules
    {
        public static int CheckIfLegalMove(ChessPiece Piece, List<MovementOptions> AllLegalMovesForThisPiece, int direction, int walkingLength, bool outOfBounds, bool friendlyAhead, bool enemyAhead, int FuturePositionX, int FuturePositionY)
        {
            Logger.TotalMovesAnalyzed();

            //I added that if a piece wants to take another piece, then CanStrike has to be true, and if a piece wants to just move, then CanMove must be true. this enforces the CanMove & CanStrike bools in our pieces.
            if ((!outOfBounds && !friendlyAhead) && ((enemyAhead && Piece.AllMoveOptionsForThisPiece[direction].CanStrike) || (!enemyAhead && Piece.AllMoveOptionsForThisPiece[direction].CanMove)))
            {
                walkingLength = AIMoveData.CreateMovementOption(Piece, AllLegalMovesForThisPiece, direction, walkingLength, enemyAhead, FuturePositionX, FuturePositionY);
            }
            else
            {
                walkingLength = 100;
            }
            return walkingLength;
        }
        public static bool CheckIfGameOver(bool continuePlaying, PlayerPieces AIWhiteComp, PlayerPieces AIBlackComp)
        {
            bool whiteKingAlive = true;
            bool blackKingAlive = true;

            whiteKingAlive = CheckWhiteKing(AIWhiteComp, whiteKingAlive);
            blackKingAlive = CheckBlackKing(AIBlackComp, blackKingAlive);

            if (whiteKingAlive && blackKingAlive)
            {
                continuePlaying = true;
            }
            else
            {
                continuePlaying = false;
            }
            return continuePlaying;
        }

        private static bool CheckBlackKing(PlayerPieces AIBlackComp, bool blackKingAlive)
        {
            blackKingAlive = false;
            foreach (var piece in AIBlackComp.PieceList)
            {
                if (piece.FullName == "King")
                {
                    blackKingAlive = true;
                }
            }
            return blackKingAlive;
        }

        private static bool CheckWhiteKing(PlayerPieces AIWhiteComp, bool whiteKingAlive)
        {
            whiteKingAlive = false;
            foreach (var piece in AIWhiteComp.PieceList)
            {
                if (piece.FullName == "King")
                {
                    whiteKingAlive = true;
                }
            }
            return whiteKingAlive;
        }
    }
}
