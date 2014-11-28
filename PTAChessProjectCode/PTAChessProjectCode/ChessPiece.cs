using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    /// <summary>
    /// Parent class that handles all chesspieces and their prperties
    /// </summary>
    public interface IChessPiece
    {
        string FullName { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        int teamDirection { get; set; }
        List<MovementOptions> AllMoveOptionsForThisPiece { get; set; }
        void MoveOption(int teamDirection);
        void ClearMovementoptions();        
    }
}
