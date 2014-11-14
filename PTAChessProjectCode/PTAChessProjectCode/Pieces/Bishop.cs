using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class Bishop:ChessPiece
    {
        public Bishop()
        {

            FullName = "Bishop";
            Name = "B";
            Value = 3;
        }
        public override void MoveOption(int teamDirection)
        {
            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(-1, -1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(1, 1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, 1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(1, -1, 7, true, true, id));
            AllMoveOptionsForThisPiece = possibleMoves;
        }
    }
}
