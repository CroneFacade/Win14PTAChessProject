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
    public interface ChessPiece
    {
        string FullName { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        string Name { get; set; }
        int Value { get; set; }
        int teamDirection { get; set; }
        bool canMove { get; set; }
        bool canStrike { get; set; }
        List<ChessPiece> PiecesICanKill { get; set; }
        List<MovementOptions> AllMoveOptionsForThisPiece { get; set; }
        void MoveOption(int teamDirection);

        int id { get; set; }

        //public List<List<string>> PieceMovement { get; set; }
        // 


        // Temporär lista vilken sparar samtliga coordinater en pjäs tillåts att flytta till.
        // Varje pjäs får en unik lista med detta innehåll.

        //public List<List<string>> TurnAvailableMoves { get; set; }




        void ClearMovementoptions();

        
    }
}

        //OLD
        //public int PositionX { get; set; }
        //public int PositionY { get; set; }
        //public int Value { get; set; }
        //public int ID { get; set; }
        //public string Name { get; set; }

        //public bool CanMove { get; set; }

        //public List<MovementOptions> MoveOpt = new List<MovementOptions>();
        //public virtual void MoveOption(int teamDirection)
        //{
        //    List<MovementOptions> possibleMoves = new List<MovementOptions>();
        //    MoveOpt = possibleMoves;
        //}
        
        //public virtual string Describe()
        //{
        //    return " "+PositionX + PositionY;
