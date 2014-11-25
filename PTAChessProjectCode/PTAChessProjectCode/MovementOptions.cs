using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTAChessProjectCode
{
    /// <summary>
    /// Class that handles the rules of movement for each piec.
    /// </summary>
    public class MovementOptions
    {
       public int PositionX = 0;
       public int PositionY = 0;
       public int WalkingLength = 0;
       public int IDOfMyPiece = -1;
       public bool CanMove { get; set; }
       public bool CanStrike { get; set; }
       public ChessPiece EnemyPiece { get; set; }
       public ChessPiece MyPiece { get; set; }
       public string MyTeam { get; set; }

       public int CheckForEnemyResult = 0;
       
       public MovementOptions(int x, int y, int length, bool canMove, bool canStrike)
       {
           PositionX = x;
           PositionY = y;
           this.WalkingLength = length;
           this.CanMove = canMove;
           this.CanStrike = canStrike;
       }
    }
}
