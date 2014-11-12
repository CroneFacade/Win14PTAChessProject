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
            Name = "Q";
            Value = 9;
        }
        public override void MoveOption(int teamDirection)
        {
            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(1, 0, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, 0, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(0, 1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(0, -1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(1, 1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(1, -1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, -1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, 1, 7, true, true, id));
            AllMoveOptionsForThisPiece = possibleMoves;

        }
    }
}
