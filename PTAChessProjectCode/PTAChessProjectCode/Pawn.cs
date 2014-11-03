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

            //Diagonally Right
            MovementOptions Move1 = new MovementOptions(PositionX + 1, PositionY + teamDirection);
            //Diagonally Left
            MovementOptions Move2 = new MovementOptions(PositionX - 1, PositionY + teamDirection);
            //Straight Ahead
            MovementOptions Move3 = new MovementOptions(PositionX, PositionY + teamDirection);

            possibleMoves.Add(Move1);
            possibleMoves.Add(Move2);
            possibleMoves.Add(Move3);

            MoveOpt = possibleMoves;
        }
    }
}
