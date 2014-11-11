using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class Queen: ChessPiece
    {
        public Queen()
        {
            Value = 9;
        }
        public override void MoveOption()
        {
            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY, 7));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY, 7));
            possibleMoves.Add(new MovementOptions(PositionX, PositionY + 1, 7));
            possibleMoves.Add(new MovementOptions(PositionX, PositionY - 1, 7));
            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY + 1, 7));
            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY - 1, 7));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY - 1, 7));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY + 1, 7));
            MoveOpt = possibleMoves;

        }
    }
}
