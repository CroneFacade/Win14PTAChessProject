using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class ChessPiece
    {
        public string TeamWhite = "White";
        public string TeamBlack = "Black";
        public string TeamNeutral = "Neutral";

        public string king = "K";
        public string pawn = "P";
        public string queen = "Q";
        public string rook = "R";
        public string knight = "k";
        public string bishop = "B";
        public string empty = "0";

        public ChessPiece(string p1, string p2)
        {
            Team = p1;
            PieceType = p2;
        }

        public ChessPiece()
        {
            // TODO: Complete member initialization
        }

        public string Team { get; set; }        
        public string PieceType { get; private set; }

        public string Coordinate { get; set; }
        

    }
}
