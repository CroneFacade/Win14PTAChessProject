using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    public class Pawn : ChessPiece
    {
        
        
        public override string Describe()
        {
            return "Pawn "+ PositionX+PositionY;
        }
        public List<string> MoveOption(int teamDirection) // <-- In order to know how the pawn can move we need to know its team. team white = -1, team black = 1
        {
            //ToDo: enter logic for moving Pawn

            //TEMPORARY CODE, THIS IS SUBJECT TO CHANGE
            int moveForward = PositionY + teamDirection; // moving 1 step forwards
            int moveLeft = PositionX - 1; // moving 1 left
            int moveRight = PositionX + 1; // moving 1 right

            List<string> possibleMoves = new List<string>();

            possibleMoves.Add(moveLeft + "," + moveForward);
            possibleMoves.Add(moveRight + "," + moveForward);
            possibleMoves.Add(PositionX+","+moveForward);     //this will add a string with ( "X,Y" ) to the List
                                                               //The AI can then later split all these strings in to a seperate X and Y position and use that
                                                                //To check whats on that position to get the values etc.
            
            return possibleMoves;                              
        }
    }
}
