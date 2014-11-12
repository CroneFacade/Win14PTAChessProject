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
            Name = "k";
            Value=3;
        }
        public override void MoveOption(int teamDirection)
        {
            List<MovementOptions> possibleMoves = new List<MovementOptions>();


            possibleMoves.Add(new MovementOptions(-1, -2, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(1, -2, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(2, -1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(2, 1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(1, 2, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, 2, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(-2, 1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(-2, -1, 1, true, true, id));
            AllMoveOptionsForThisPiece = possibleMoves;
        }

    }
}
