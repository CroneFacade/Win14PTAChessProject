using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class King : ChessPiece
    {
        public string FullName { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int teamDirection { get; set; }
        public bool canMove { get; set; }
        public bool canStrike { get; set; }
        public List<ChessPiece> PiecesICanKill { get; set; }
        public int id { get; set; }
        public void ClearMovementoptions()
        {
            AllMoveOptionsForThisPiece.Clear();
        }

        public List<MovementOptions> AllMoveOptionsForThisPiece { get; set; }
         
        public King()
        {
            AllMoveOptionsForThisPiece = new List<MovementOptions>();
            FullName = "King";
            Name = "K";
            Value = 10;
        }
        public void MoveOption(int teamDirection) // <-- In order to know how the pawn can move we need to know its team. team white = -1, team black = 1
        {

            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(1, 0, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, 0, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(0, 1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(0, -1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(1, 1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(1, -1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, -1, 1, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, 1, 1, true, true, id));
            AllMoveOptionsForThisPiece = possibleMoves;
        }
    }
}
