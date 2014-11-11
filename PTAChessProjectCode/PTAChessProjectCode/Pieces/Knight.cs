using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class Knight:ChessPiece
    {
        public Knight()
        {
            Value=3;
        }
        public override void MoveOption(int teamDirection)
        {
            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY - 2, 1, true, true));
            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY - 2, 1, true, true));
            possibleMoves.Add(new MovementOptions(PositionX + 2, PositionY - 1, 1, true, true));
            possibleMoves.Add(new MovementOptions(PositionX + 2, PositionY + 1, 1, true, true));
            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY + 2, 1, true, true));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY + 2, 1, true, true));
            possibleMoves.Add(new MovementOptions(PositionX - 2, PositionY + 1, 1, true, true));
            possibleMoves.Add(new MovementOptions(PositionX - 2, PositionY - 1, 1, true, true));
            MoveOpt = possibleMoves;
        }

    }
}
