using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class ChessPieceCanTakeAction
    {

        ChessPiece ThePiece { get; private set; }
        List<MovementOptions> PlacesICanMoveTo { get; private set; }
        List<MovementOptions> PlacesICanKillSomeone { get; private set; }

        public ChessPieceCanTakeAction(ChessPiece thePiece, List<MovementOptions> placesICanMoveTo, List<MovementOptions> placesICanKillSomeone)
        {
            ThePiece = thePiece;
            PlacesICanMoveTo = placesICanMoveTo;
            PlacesICanKillSomeone = placesICanKillSomeone;
        }


    }

    
}
