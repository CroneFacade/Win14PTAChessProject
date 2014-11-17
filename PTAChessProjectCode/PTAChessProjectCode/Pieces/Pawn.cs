using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    public class Pawn : ChessPiece
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
        public Pawn()
        {
            AllMoveOptionsForThisPiece = new List<MovementOptions>();
            FullName = "Pawn";
            Name = "P";
            Value = 1;
        }
        public void MoveOption(int teamDirection) // <-- In order to know how the pawn can move we need to know its team. team white = -1, team black = 1
        {

            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(1, 0 + teamDirection, 1, false, true, id));
            possibleMoves.Add(new MovementOptions(-1, 0 + teamDirection, 1, false, true, id));
            possibleMoves.Add(new MovementOptions(0, 0 + teamDirection, 1, true, false, id));

            AllMoveOptionsForThisPiece = possibleMoves;
        }
    }
}
