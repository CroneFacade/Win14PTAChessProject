﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class Queen: ChessPiece
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
        public Queen()
        {
            AllMoveOptionsForThisPiece = new List<MovementOptions>();
            FullName = "Queen";
            Name = "Q";
            Value = 9;
        }
        public void MoveOption(int teamDirection)
        {
            List<MovementOptions> possibleMoves = new List<MovementOptions>();

            possibleMoves.Add(new MovementOptions(1, 0, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, 0, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(0, 1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(0, -1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(1, 1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(1, -1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, -1, 7, true, true, id));
            possibleMoves.Add(new MovementOptions(-1, 1, 7, true, true, id));
            AllMoveOptionsForThisPiece = possibleMoves;

        }
    }
}
