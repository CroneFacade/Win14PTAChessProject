﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class King : ChessPiece
    {
        private string team;

        


        public King(string team)
        {
            Name = "K";
            this.team = team;

        }
    }
}
