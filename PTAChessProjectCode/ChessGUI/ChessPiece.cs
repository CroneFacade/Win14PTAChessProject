using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGUI
{
    public abstract class ChessPiece
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int teamDirection { get; set; }
        public bool canMove = true;
        public bool canStrike = true;
        public List<ChessPiece> PiecesICanKill { get; set; }

        public List<MovementOptions> MoveOpt = new List<MovementOptions>();
        public virtual void MoveOption(int teamDirection)
        {
            List<MovementOptions> possibleMoves = new List<MovementOptions>();
            MoveOpt = possibleMoves;
        }

        public int id { get; set; }

        //public List<List<string>> PieceMovement { get; set; }
        // 
        public List<string> Coordinates { get; set; }

        // Temporär lista vilken sparar samtliga coordinater en pjäs tillåts att flytta till.
        // Varje pjäs får en unik lista med detta innehåll.

        public List<List<string>> TurnAvailableMoves { get; set; }


    }
}
