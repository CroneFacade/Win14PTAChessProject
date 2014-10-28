using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class Pawn : ChessPiece
    {
        private string team;


        public Pawn(string team)
        {

            this.team = team;

        }
    }
}
