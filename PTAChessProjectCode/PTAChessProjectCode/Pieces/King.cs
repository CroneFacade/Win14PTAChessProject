using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class King : ChessPiece
    {
         
        public King()
        {
            Name = "K";
            Value = 10;
        }
        public override void MoveOption(int teamDirection) // <-- In order to know how the pawn can move we need to know its team. team white = -1, team black = 1
        {

            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX, PositionY + 1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX, PositionY - 1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY + 1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY - 1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY - 1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY + 1, 1, true, true, id));
            AllMoveOptionsForThisPiece = possibleMoves;
        }
    }
}
