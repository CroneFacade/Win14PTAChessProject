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
    }
}
