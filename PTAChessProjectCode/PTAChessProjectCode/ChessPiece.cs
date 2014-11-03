using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    public abstract class ChessPiece
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Value { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }

        public bool CanMove { get; set; }

        public List<MovementOptions> MoveOpt = new List<MovementOptions>();
        public virtual void MoveOption(int teamDirection)
        {

        }
        
        public virtual string Describe()
        {
            return " "+PositionX + PositionY;
        }
    }
}
