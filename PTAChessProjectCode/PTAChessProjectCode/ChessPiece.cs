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

        public string king = "King";
        public string pawn = "Pawn";
        public string queen = "Queen";
        public string rook = "Rook";
        public string knight = "Knight";
        public string bishop = "Bishop";
        public string empty = "Empty";

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
