using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class Rook:ChessPiece
    {
        public Rook()
        {
            Name = "R";
            Value = 5;
        }
        public override void MoveOption(int teamDirection)
        {
            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(PositionX, PositionY - 1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX, PositionY + 1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY, 7, true, true, id));
            AllMoveOptionsForThisPiece = possibleMoves;
        }
    }
}
