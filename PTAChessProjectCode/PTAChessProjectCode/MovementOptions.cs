using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTAChessProjectCode
{
    public class MovementOptions
    {
       public int PositionX = 0;
       public int PositionY = 0;
       public int WalkingLength = 0;
       public int PositionValue = 0;
       public int IDOfMyPiece = -1;
       public bool CanMove { get; set; }
       public bool CanStrike { get; set; }

       
       public MovementOptions(int x, int y, int length, bool canMove, bool canStrike)
       {
           PositionX = x;
           PositionY = y;
       }
    }
}
