using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    public class Pawn : ChessPiece
    {

        public Pawn()
        {
            Name = "P";
            Value = 1;
        }
        public override void MoveOption(int teamDirection) // <-- In order to know how the pawn can move we need to know its team. team white = -1, team black = 1
        {

            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(1, 0 + teamDirection, 1, false, true, id));
            possibleMoves.Add(new MovementOptions(-1, 0 + teamDirection, 1, false, true, id));
            possibleMoves.Add(new MovementOptions(0, 0 + teamDirection, 1, true, false, id));

            AllMoveOptionsForThisPiece = possibleMoves;
        }
    }
}
