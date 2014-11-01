using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    class AI
    {
        public List<ChessPiece> MyTeamPieces { get; set; }
        public List<ChessPiece> EnemyTeamPieces { get; set; }

        private bool enemyTeamLost = false;
        public AI(List<ChessPiece> MyTeamPieces, List<ChessPiece> EnemyTeamPieces)
        {
            this.MyTeamPieces = MyTeamPieces;
            this.EnemyTeamPieces = EnemyTeamPieces;
        }

        internal void InitTurn(int p)
        {
            //Heres the brains of the AI which alters MyTeamPieces and EnemyTeamPieces
            //throw new NotImplementedException();
        }

        internal List<ChessPiece> GetMyPieces()
        {
            return MyTeamPieces;
        }

        internal List<ChessPiece> GetEnemyPieces()
        {
            return EnemyTeamPieces;
        }

        internal bool DidEnemyTeamLose()
        {
            return enemyTeamLost;
        }

        internal void UpdatePieces(List<ChessPiece> MyTeamPieces, List<ChessPiece> EnemyTeamPieces)
        {
            this.MyTeamPieces = MyTeamPieces;
            this.EnemyTeamPieces = EnemyTeamPieces;
        }
    }
}
