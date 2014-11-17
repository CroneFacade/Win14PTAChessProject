using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    public class Logger
    {
        //This is our complete log list of all movements
        public static List<string> CompleteMoveLog = new List<string>();

        //This is a counter of all analyzed moves
        public static int TotalAnalyzedMoves { get; set; }

        //This is a counter of all Legal analyzed moves
        public static int TotalAmountOfLegalAnalyzedMoves { get; set; }

        //The currently newest log
        public static string newestLog { get; set; }
        
        //This Method resets the logs for a new game
        internal static void CreateCleanLog()
        {
            CompleteMoveLog = new List<string>();
            TotalAnalyzedMoves = 0;
            TotalAmountOfLegalAnalyzedMoves = 0;
        }

        //This method adds to the TotalAnalyzedMoves counter
        internal static void TotalMovesAnalyzed()
        {
            TotalAnalyzedMoves++;
        }

        //This method adds to the TotalAmountOfLegalAnalyzedMoves counter
        internal static void AmountOfLegalAnalyzedMoves(int amountOfMoves)
        {
            TotalAmountOfLegalAnalyzedMoves += amountOfMoves;
        }


        //This Method adds a new log entry
        internal static void AddMoveToLog(MovementOptions optimalMovementOption)
        {
            //_The New Log__My Team (White or Black)________The Full Name of the Piece we moved_______________________Old PositionX___________________________________Old PositionY_______________________________NewX_______________________________NewY
            string log = optimalMovementOption.MyTeam + " " + optimalMovementOption.MyPiece.FullName + " moved from " + optimalMovementOption.MyPiece.PositionX + "," + optimalMovementOption.MyPiece.PositionY + " to " + optimalMovementOption.PositionX + "," + optimalMovementOption.PositionY;
            
            //Save the newest Log
            newestLog = log;
            
            //Add the new log to the complete list
            CompleteMoveLog.Add(log);
        }






        //This method adds a log which explains which piece defeated which piece and where.
        internal static void AddPieceStrikeToLog(MovementOptions pieceToMove)
        {
            string log = pieceToMove.MyTeam + " " + pieceToMove.MyPiece.FullName + " moved from " + pieceToMove.MyPiece.PositionX + "," + pieceToMove.MyPiece.PositionY + " and removed an enemy " + pieceToMove.EnemyPiece.FullName + " at position " + pieceToMove.PositionX + "," + pieceToMove.PositionY;
            
            //Save the newest Log
            newestLog = log;

            //Add the new log to the complete list
            CompleteMoveLog.Add(log);
        }
    }
}
