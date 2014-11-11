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
            Value = 1;
        }
        public override string Describe()
        {
            return "Pawn " + PositionX + PositionY;
        }
        public override void MoveOption(int teamDirection) // <-- In order to know how the pawn can move we need to know its team. team white = -1, team black = 1
        {

            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY + teamDirection, 1));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY + teamDirection, 1));
            possibleMoves.Add(new MovementOptions(PositionX, PositionY + teamDirection, 1));

            MoveOpt = possibleMoves;
        }
    }
}
