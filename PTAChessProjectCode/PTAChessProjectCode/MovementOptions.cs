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
       public int PositionValue = 0;
       public int IDOfMyPiece = -1;
       
       public MovementOptions(int p1, int p2)
       {
           PositionX = p1;
           PositionY = p2;
       }
    }
}
