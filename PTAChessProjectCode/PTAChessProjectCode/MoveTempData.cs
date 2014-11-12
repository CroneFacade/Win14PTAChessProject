using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class MoveTempData
    {
        List<ChessPiece> FriendlyTempPieceList { get; set; }
        List<ChessPiece> EnemyTempPieceList { get; set; }
        //List <ChessPieceCanTakeAction> CanTakeActionList { get; set; }




        public MoveTempData()
        {
            List<ChessPieceCanTakeAction> CanTakeActionList = new List<ChessPieceCanTakeAction>();

        }

        public void CreateTempChessPiece(ChessPiece thePiece, List<MovementOptions> placesICanMoveTo, List<MovementOptions> placesICanKillSomeone)
        {
            ChessPieceCanTakeAction CanTakeAction = new ChessPieceCanTakeAction(thePiece, placesICanMoveTo, placesICanKillSomeone);
            CanTakeActionList.Add(CanTakeAction);
        }





        







        






    }
}
