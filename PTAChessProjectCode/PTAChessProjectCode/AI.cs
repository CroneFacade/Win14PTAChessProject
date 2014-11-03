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

        internal void InitTurn(int teamDirection)
        {
            List<List<MovementOptions>> AllAnalyzedMoves = new List<List<MovementOptions>>();
            AllAnalyzedMoves = AnalyzeMyPieces(teamDirection);
            FindEnemies(AllAnalyzedMoves);
            
        }

        public int funnyCounter;

        private List<MovementOptions> FindEnemies(List<List<MovementOptions>> AllAnalyzedMoves)
        {
            List<MovementOptions> EnemiesWeCanTarget = new List<MovementOptions>();
            funnyCounter = 0;
            foreach (var ListOfMovesFromPiece in AllAnalyzedMoves)
            {
                foreach (var movementOption in ListOfMovesFromPiece)
                {
                    foreach (var piece in EnemyTeamPieces)
                    {
                        if (movementOption.PositionX == piece.PositionX && movementOption.PositionY == piece.PositionY)
                        {
                            movementOption.PositionValue = piece.Value;
                            movementOption.IDOfMyPiece = piece.ID;
                            EnemiesWeCanTarget.Add(movementOption);
                        }
                        funnyCounter++;
                    }
                }
            }
            return EnemiesWeCanTarget;
        }

        private List<List<MovementOptions>> AnalyzeMyPieces(int teamDirection)
        {
            List<List<MovementOptions>> AnalyzedMoves = new List<List<MovementOptions>>();
            foreach (var piece in MyTeamPieces)
            {
                piece.MoveOption(teamDirection);
                AnalyzedMoves.Add(piece.MoveOpt);
            }
            return AnalyzedMoves;
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

        private int randomNumber;
        public void GenerateRandomNumber(List<ChessPiece> pieces)
        {
            Random rnd = new Random();
            int max = pieces.Count;
            int min = 0;

            int rndNum = rnd.Next(min, max);
            randomNumber = rndNum;
        }
    }
}
