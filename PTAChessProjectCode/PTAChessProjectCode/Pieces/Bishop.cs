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
            Value = 3;
        }
        public override void MoveOption(int teamDirection)
        {
            List<MovementOptions> possibleMoves = new List<MovementOptions>(); 
            
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY - 1, 7, true, true));
            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY + 1, 7, true, true));
            possibleMoves.Add(new MovementOptions(PositionX - 1, PositionY + 1, 7, true, true));
            possibleMoves.Add(new MovementOptions(PositionX + 1, PositionY - 1, 7, true, true));
            MoveOpt = possibleMoves;
        }
    }
}
