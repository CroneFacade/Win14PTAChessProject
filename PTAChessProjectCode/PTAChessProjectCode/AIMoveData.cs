using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    /// <summary>
    /// This class actually contains all of our AI logic and nothing else, This class should be named AI, or AI logic, or AI_Move_logic/data or something similar.
    /// </summary>
    public class AIMoveData
    {
        private PlayerPieces AIToMove { get; set; }
        private PlayerPieces AINotToMove { get; set; }
        //private List<ChessPiece> EnemyAIPieces { get; set; }
        public List<ChessPiece> PieceThatCanMove { get; set; }
        public List<ChessPiece> PieceThatCanKill { get; set; }

        public List<ChessPiece> EnemyPiecePositions { get; set; }
        public List<string> AllMoves { get; set; }

        public AIMoveData(PlayerPieces playerToMove, PlayerPieces playerNotToMove)
        {
            this.AIToMove = playerToMove;
            this.AINotToMove = playerNotToMove;
            this.EnemyPiecePositions = playerNotToMove.PieceList;
            AllMoves = new List<string>();
            PieceThatCanMove = new List<ChessPiece>();
            PieceThatCanKill = new List<ChessPiece>();
        }

        // Vi har en metod MakeMove, en annan AIMakeMove....
        public List<ChessPiece> MakeMove(PlayerPieces playerToMove, List<ChessPiece> enemyList)
        {
            this.AIToMove = playerToMove;
            this.EnemyPiecePositions = enemyList;

            List<ChessPiece> AfterMoveList = AIMakeMove(AIToMove);
            return AfterMoveList;
        }

        private void SetNewAIToMakeMove(PlayerPieces playerToMove)
        {
            this.AIToMove = playerToMove;
        }

        public List<ChessPiece> AIMakeMove(PlayerPieces AIToMove)
        {

            List<List<MovementOptions>> AllMovesMyPiecesCanMake = AnalyzeMyPieces(AIToMove.PieceList);

            Logger.AmountOfLegalAnalyzedMoves(AllMovesMyPiecesCanMake.Count);

            if (AllMovesMyPiecesCanMake.Count == 0)
            {
                AIToMove.PieceList.Clear();
                return AIToMove.PieceList;
            }

            List<MovementOptions> PiecesICanKill = FindPiecesICanKill(AllMovesMyPiecesCanMake);

            MovementOptions optimalMovementOption;

            if (PiecesICanKill.Count != 0)
            {
                optimalMovementOption = FindHighestPieceValue(PiecesICanKill);
            }
            else
            {
                int randomNumber = GetRandomNumber(0, AllMovesMyPiecesCanMake.Count);
                int randomPiece = AllMovesMyPiecesCanMake[randomNumber].Count;
                int randomMovementOption = GetRandomNumber(0, randomPiece);

                optimalMovementOption = AllMovesMyPiecesCanMake[randomNumber][randomMovementOption];
            }

            Logger.LogDecidedMove(optimalMovementOption);

            MovePiece(optimalMovementOption, AIToMove.PieceList, EnemyPiecePositions);
            return AIToMove.PieceList;
        }


        /* Förklara metoden, hur räknar vi ut högsta värde på ett drag */
        private MovementOptions FindHighestPieceValue(List<MovementOptions> PiecesICanKill)
        {
            var highestValueFound = 0;
            MovementOptions optimalMovementOption = null;
            foreach (var movementOption in PiecesICanKill)
            {
                /* Förklaring till if satsen */
                if ((highestValueFound < movementOption.EnemyPiece.Value) || ((highestValueFound == movementOption.EnemyPiece.Value) && (optimalMovementOption.MyPiece.Value > movementOption.MyPiece.Value)))
                {
                    highestValueFound = movementOption.EnemyPiece.Value;
                    optimalMovementOption = movementOption;
                }
            }
            return optimalMovementOption;
        }

        private List<MovementOptions> FindPiecesICanKill(List<List<MovementOptions>> AllMovesMyPiecesCanMake)
        {
            List<MovementOptions> PiecesICanKill = new List<MovementOptions>();

            foreach (var movementList in AllMovesMyPiecesCanMake)
            {
                foreach (var movementOption in movementList)
                {
                    if (movementOption.CheckForEnemyResult == 1)
                    {

                        PiecesICanKill.Add(AddEnemyPieceToMovementOption(movementOption));
                    }
                }
            }

            return PiecesICanKill;
        }

        private MovementOptions AddEnemyPieceToMovementOption(MovementOptions movementOption)
        {
            foreach (var piece in EnemyPiecePositions)
            {
                if ((movementOption.PositionX == piece.PositionX) && (movementOption.PositionY == piece.PositionY))
                {
                    movementOption.EnemyPiece = piece;
                    return movementOption;
                }
            }
            return movementOption;
        }

        private void MovePiece(MovementOptions pieceToMove, List<ChessPiece> list, List<ChessPiece> EnemyPiecePositions)
        {
            pieceToMove.MyPiece.PositionX = pieceToMove.PositionX;
            pieceToMove.MyPiece.PositionY = pieceToMove.PositionY;

            if (pieceToMove.CheckForEnemyResult == 1)
            {
                RemoveEnemyPiece(pieceToMove.EnemyPiece);
            }

        }

        private void RemoveEnemyPiece(ChessPiece pieceToRemove)
        {
            EnemyPiecePositions.Remove(pieceToRemove);
        }

        private List<List<MovementOptions>> AnalyzeMyPieces(List<ChessPiece> list)
        {
            var AllMoves = new List<List<MovementOptions>>();
            CheckAllMyPieces(list, AllMoves);

            return AllMoves;
        }

        private void CheckAllMyPieces(List<ChessPiece> list, List<List<MovementOptions>> AllMoves)
        {
            foreach (var Piece in list)
            {
                Piece.ClearMovementoptions();
                Piece.MoveOption(Piece.teamDirection);

                var AllLegalMovesForThisPiece = new List<MovementOptions>();

                CheckAllDirections(list, Piece, AllLegalMovesForThisPiece);

                if (AllLegalMovesForThisPiece.Count != 0)
                {
                    AllMoves.Add(AllLegalMovesForThisPiece);
                }
            }
        }

        private void CheckAllDirections(List<ChessPiece> list, ChessPiece Piece, List<MovementOptions> AllLegalMovesForThisPiece)
        {
            for (int direction = 0; direction < Piece.AllMoveOptionsForThisPiece.Count; direction++)
            {

                Piece.ClearMovementoptions();
                Piece.MoveOption(Piece.teamDirection);

                CheckLengthInDirection(list, Piece, AllLegalMovesForThisPiece, direction);

            }
        }

        private void CheckLengthInDirection(List<ChessPiece> list, ChessPiece Piece, List<MovementOptions> AllLegalMovesForThisPiece, int direction)
        {
            for (int walkingLength = 1; walkingLength <= Piece.AllMoveOptionsForThisPiece[direction].WalkingLength; walkingLength++)
            {
                var outOfBounds = false;
                var friendlyAhead = false;
                var enemyAhead = false;
                Piece.ClearMovementoptions();
                Piece.MoveOption(Piece.teamDirection);

                int MovingPositionX = Piece.AllMoveOptionsForThisPiece[direction].PositionX * walkingLength;
                int MovingPositionY = Piece.AllMoveOptionsForThisPiece[direction].PositionY * walkingLength;

                int FuturePositionX = Piece.PositionX + MovingPositionX;
                int FuturePositionY = Piece.PositionY + MovingPositionY;

                outOfBounds = CheckIfOutOfBounds(FuturePositionX, FuturePositionY);
                friendlyAhead = CheckIfFriendlyAhead(FuturePositionX, FuturePositionY, list);
                enemyAhead = CheckIfEnemyAhead(FuturePositionX, FuturePositionY, EnemyPiecePositions);

                walkingLength = CheckIfLegalMove(Piece, AllLegalMovesForThisPiece, direction, walkingLength, outOfBounds, friendlyAhead, enemyAhead, FuturePositionX, FuturePositionY);

            }
        }

        private static int CheckIfLegalMove(ChessPiece Piece, List<MovementOptions> AllLegalMovesForThisPiece, int direction, int walkingLength, bool outOfBounds, bool friendlyAhead, bool enemyAhead, int FuturePositionX, int FuturePositionY)
        {
            Logger.TotalMovesAnalyzed();

            //I added that if a piece wants to take another piece, then CanStrike has to be true, and if a piece wants to just move, then CanMove must be true. this enforces the CanMove & CanStrike bools in our pieces.
            if ((!outOfBounds && !friendlyAhead) && ((enemyAhead && Piece.AllMoveOptionsForThisPiece[direction].CanStrike) || (!enemyAhead && Piece.AllMoveOptionsForThisPiece[direction].CanMove)))
            {
                walkingLength = CreateMovementOption(Piece, AllLegalMovesForThisPiece, direction, walkingLength, enemyAhead, FuturePositionX, FuturePositionY);
            }
            else
            {
                walkingLength = 100;
            }
            return walkingLength;
        }

        private static int CreateMovementOption(ChessPiece Piece, List<MovementOptions> AllLegalMovesForThisPiece, int direction, int walkingLength, bool enemyAhead, int FuturePositionX, int FuturePositionY)
        {
            MovementOptions MoveChoice = Piece.AllMoveOptionsForThisPiece[direction];

            MoveChoice.MyPiece = Piece;

            if (enemyAhead)
            {
                MoveChoice.CheckForEnemyResult = 1;
                walkingLength = 100;
            }

            if (Piece.teamDirection == -1)
            {
                Piece.AllMoveOptionsForThisPiece[direction].MyTeam = "White";
            }
            else
            {
                Piece.AllMoveOptionsForThisPiece[direction].MyTeam = "Black";
            }

            Piece.AllMoveOptionsForThisPiece[direction].PositionX = FuturePositionX;
            Piece.AllMoveOptionsForThisPiece[direction].PositionY = FuturePositionY;
            AllLegalMovesForThisPiece.Add(Piece.AllMoveOptionsForThisPiece[direction]);
            Piece.AllMoveOptionsForThisPiece[direction] = MoveChoice;
            return walkingLength;
        }

        private bool CheckIfEnemyAhead(int FuturePositionX, int FuturePositionY, List<ChessPiece> EnemyPiecePositions)
        {
            foreach (var piece in EnemyPiecePositions)
            {
                if (piece.PositionX == FuturePositionX && piece.PositionY == FuturePositionY)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckIfOutOfBounds(int futureX, int futureY)
        {
            if (((futureX > -1) && (futureX < 8)) && ((futureY > -1) && (futureY < 8)))
            {
                return false;
            }
            return true;
        }

        public bool CheckIfFriendlyAhead(int futureX, int futureY, List<ChessPiece> friendyPieces)
        {

            foreach (var piece in friendyPieces)
            {

                if ((futureX == piece.PositionX) && (futureY == piece.PositionY))
                {
                    return true;
                }
            }
            return false;
        }

        public MovementOptions PickPiece(List<ChessPiece> pieces)
        {
            int randomNumber = 0;
            bool NotBlocked = false;
            MovementOptions ChosenMovementOption = null;
            while (!NotBlocked)
            {

                randomNumber = GetRandomNumber(pieces);


                List<MovementOptions> CurrentPieceMoveOptions = pieces[randomNumber].AllMoveOptionsForThisPiece;


                foreach (var MoveOption in CurrentPieceMoveOptions)
                {
                    foreach (var Piece in pieces)
                    {
                        if ((MoveOption.PositionY > -1 && MoveOption.PositionY < 8) && (MoveOption.PositionX > -1 && MoveOption.PositionX < 8))
                        {
                            if ((pieces[randomNumber].PositionX + MoveOption.PositionX == Piece.PositionX) && (pieces[randomNumber].PositionY + MoveOption.PositionY == Piece.PositionY))
                            {
                                NotBlocked = false;
                            }
                            else
                            {
                                NotBlocked = true;
                                ChosenMovementOption = MoveOption;
                                break;
                            }
                        }
                    }
                }
            }
            return ChosenMovementOption;
        }

        public int GetRandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(min, max);
            return randomNumber;
        }


        public int GetRandomNumber(List<ChessPiece> pieces)
        {
            Random rnd = new Random();
            int max = pieces.Count + 1;
            int min = 1;
            int randomNumber = rnd.Next(min, max);
            return randomNumber - 1;
        }
    }
}
