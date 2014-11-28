using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    /// <summary>
    /// This class contains the AI logic regarding moves.  
    /// </summary>
    public class AIMoveData
    {
        private PlayerPieces AIToMove { get; set; }
        private PlayerPieces AINotToMove { get; set; }
        public List<IChessPiece> EnemyPiecePositions { get; set; }

        //Constructor generating white and black pieces, also instantiates list of all possible moves, all allowed moves and all pieces that can kill an opponent. 
        public AIMoveData(PlayerPieces MyPieces, PlayerPieces EnemyPieces)
        {
            this.AIToMove = MyPieces;
            this.AINotToMove = EnemyPieces;
            this.EnemyPiecePositions = EnemyPieces.PieceList;

        }

        //Sets up the move of the current player. 
        public List<IChessPiece> MakeMove(PlayerPieces playerToMove, List<IChessPiece> enemyList)
        {
            this.AIToMove = playerToMove;
            this.EnemyPiecePositions = enemyList;

            List<IChessPiece> AfterMoveList = AIMakeMove(AIToMove);
            return AfterMoveList;
        }

        //Logic deciding which move to make for current player. 
        public List<IChessPiece> AIMakeMove(PlayerPieces AIToMove)
        {
            List<List<MovementOptions>> AllMovesMyPiecesCanMake = AnalyzeMyPieces(AIToMove.PieceList, EnemyPiecePositions);

            List<MovementOptions> FilteredMovesToKeepKingSafe = RemoveOptionsThatThreatenKing(AllMovesMyPiecesCanMake);

            Logger.AmountOfLegalAnalyzedMoves(AllMovesMyPiecesCanMake.Count);

            if (FilteredMovesToKeepKingSafe.Count == 0)
            {
                Logger.AddMessageToLog(AIToMove.TeamName + " Has lost the game.");
                AIToMove.PieceList.Clear();
                return AIToMove.PieceList;
            }

            List<MovementOptions> PiecesICanKill = FindPiecesICanKill(FilteredMovesToKeepKingSafe);

            MovementOptions optimalMovementOption;

            if (PiecesICanKill.Count != 0)
            {
                optimalMovementOption = FindHighestPieceValue(PiecesICanKill);
            }
            else
            {
                List<MovementOptions> MovesWherePieceCanStrikeNextTurn = FindSomeoneToKillNextTurn(FilteredMovesToKeepKingSafe);

                if (MovesWherePieceCanStrikeNextTurn.Count != 0)
                {
                    optimalMovementOption = FindHighestPieceValue(MovesWherePieceCanStrikeNextTurn);
                }
                else
                {
                    int MaxIndex = FilteredMovesToKeepKingSafe.Count;
                    int randomMovementOption = GetRandomNumber(0, MaxIndex);

                    optimalMovementOption = FilteredMovesToKeepKingSafe[randomMovementOption];
                }
            }
            Logger.LogDecidedMove(optimalMovementOption);

            MovePiece(optimalMovementOption, AIToMove.PieceList, EnemyPiecePositions);

            CheckIfPawnIsAtEndOfBoard(AIToMove.PieceList);

            return AIToMove.PieceList;
        }

        private List<MovementOptions> FindSomeoneToKillNextTurn(List<MovementOptions> FilteredMovesToKeepKingSafe)
        {
            var OptimalMoves = new List<MovementOptions>();

            foreach (var Move in FilteredMovesToKeepKingSafe)
            {
                Logger.TotalMovesAnalyzed();

                SaveOldPosition(Move);
                MakeHypotheticalMove(Move);

                var HypotheticalPieceList = AnalyzeMyPieces(AIToMove.PieceList, EnemyPiecePositions);
                var HypotheticalMovesWhichDontEndangerKing = RemoveOptionsThatThreatenKing(HypotheticalPieceList);
                var HypotheticalMovesThatCanKill = FindPiecesICanKill(HypotheticalMovesWhichDontEndangerKing);

                UndoMove(Move);



                if (HypotheticalMovesThatCanKill.Count > 0 && !(Move.MyPiece.FullName == "King"))
                {
                    Move.EnemyPiece = HypotheticalMovesThatCanKill[0].EnemyPiece;
                    OptimalMoves.Add(Move);
                }
            }

            return OptimalMoves;
        }

        private void CheckIfPawnIsAtEndOfBoard(List<IChessPiece> MyList)
        {
            foreach (var Piece in MyList)
            {
                if (Piece.FullName == "Pawn" && (Piece.PositionY == 7 || Piece.PositionY == 0))
                {
                    AIToMove.ReplacePawnWithQueen(Piece, MyList);
                    return;
                }
            }
        }

        private List<MovementOptions> RemoveOptionsThatThreatenKing(List<List<MovementOptions>> AllMovesMyPiecesCanMake)
        {
            List<IChessPiece> EnemyPieces = EnemyPiecePositions;
            List<MovementOptions> FilteredMoves = new List<MovementOptions>();

            foreach (var PieceMoveList in AllMovesMyPiecesCanMake)
            {
                foreach (var move in PieceMoveList)
                {
                    //Save old Position
                    SaveOldPosition(move);

                    //Perform Hypothetical Move
                    MakeHypotheticalMove(move);

                    //Check enemy move options for hypothetical new board
                    List<List<MovementOptions>> EnemyMoveOptions = AnalyzeMyPieces(EnemyPieces, AIToMove.PieceList);



                    IChessPiece King = FindMyKing();

                    int KingX = King.PositionX;
                    int KingY = King.PositionY;

                    bool AllowMove = true;

                    foreach (var EnemyMoveList in EnemyMoveOptions)
                    {
                        foreach (var EnemyMove in EnemyMoveList)
                        {
                            Logger.TotalMovesAnalyzed();
                            if ((EnemyMove.PositionX == KingX) && (EnemyMove.PositionY == KingY))
                            {
                                AllowMove = false;
                            }

                        }
                    }

                    //Undo Hypothetical Move
                    UndoMove(move);

                    if (AllowMove)
                    {
                        FilteredMoves.Add(move);
                    }

                }
            }

            return FilteredMoves;
        }

        private static void UndoMove(MovementOptions move)
        {
            move.MyPiece.PositionX = move.OldPositionX;
            move.MyPiece.PositionY = move.OldPositionY;
        }

        private IChessPiece FindMyKing()
        {
            foreach (var piece in AIToMove.PieceList)
            {
                if (piece.FullName == "King")
                {
                    return piece;
                }
            }
            return null;
        }

        private static void MakeHypotheticalMove(MovementOptions move)
        {
            move.MyPiece.PositionX = move.PositionX;
            move.MyPiece.PositionY = move.PositionY;
        }

        private static void SaveOldPosition(MovementOptions move)
        {
            move.OldPositionX = move.MyPiece.PositionX;
            move.OldPositionY = move.MyPiece.PositionY;
        }

        //The enemy piece with the highest value can be killed by my piece, which has a lower value than the enemy piece. 
        private MovementOptions FindHighestPieceValue(List<MovementOptions> PiecesICanKill)
        {
            var highestValueFound = 0;
            MovementOptions optimalMovementOption = null;
            foreach (var movementOption in PiecesICanKill)
            {
                if ((highestValueFound < movementOption.EnemyPiece.Value) || ((highestValueFound == movementOption.EnemyPiece.Value) && (optimalMovementOption.MyPiece.Value > movementOption.MyPiece.Value)))
                {
                    highestValueFound = movementOption.EnemyPiece.Value;
                    optimalMovementOption = movementOption;
                }
            }
            return optimalMovementOption;
        }
        //Finds all the possible enemy pieces that the current players piece can kill and adds them to a list. 
        private List<MovementOptions> FindPiecesICanKill(List<MovementOptions> AllMovesMyPiecesCanMake)
        {
            List<MovementOptions> PiecesICanKill = new List<MovementOptions>();


            foreach (var movementOption in AllMovesMyPiecesCanMake)
            {
                if (movementOption.CheckForEnemyResult == 1)
                {

                    PiecesICanKill.Add(AddEnemyPieceToMovementOption(movementOption, EnemyPiecePositions));
                }
            }
            return PiecesICanKill;
        }
        //Checks where the enemy piece can go. 
        private MovementOptions AddEnemyPieceToMovementOption(MovementOptions movementOption, List<IChessPiece> EnemyPieces)
        {
            foreach (var piece in EnemyPieces)
            {
                if ((movementOption.PositionX == piece.PositionX) && (movementOption.PositionY == piece.PositionY))
                {
                    movementOption.EnemyPiece = piece;
                    return movementOption;
                }
            }
            return movementOption;
        }

        private void MovePiece(MovementOptions pieceToMove, List<IChessPiece> list, List<IChessPiece> EnemyPiecePositions)
        {
            pieceToMove.MyPiece.PositionX = pieceToMove.PositionX;
            pieceToMove.MyPiece.PositionY = pieceToMove.PositionY;

            if (pieceToMove.CheckForEnemyResult == 1)
            {
                if (pieceToMove.MyTeam == "White")
                {
                    Logger.WhitePoints += pieceToMove.EnemyPiece.Value;
                }
                else
                {
                    Logger.BlackPoints += pieceToMove.EnemyPiece.Value;
                }
                RemoveEnemyPiece(pieceToMove.EnemyPiece);
            }
        }

        private void RemoveEnemyPiece(IChessPiece pieceToRemove)
        {
            EnemyPiecePositions.Remove(pieceToRemove);
        }

        private List<List<MovementOptions>> AnalyzeMyPieces(List<IChessPiece> MyPieceList, List<IChessPiece> EnemyList)
        {
            var AllMoves = new List<List<MovementOptions>>();
            CheckAllMyPieces(MyPieceList, EnemyList, AllMoves);
            return AllMoves;
        }

        private void CheckAllMyPieces(List<IChessPiece> MyList, List<IChessPiece> EnemyList, List<List<MovementOptions>> AllMoves)
        {
            foreach (var Piece in MyList)
            {
                Piece.ClearMovementoptions();
                Piece.MoveOption(Piece.teamDirection);

                var AllLegalMovesForThisPiece = new List<MovementOptions>();

                CheckAllDirections(MyList, EnemyList, Piece, AllLegalMovesForThisPiece);

                if (AllLegalMovesForThisPiece.Count != 0)
                {
                    AllMoves.Add(AllLegalMovesForThisPiece);
                }
            }
        }
        //Checks whichs directions the current piece can move in.
        private void CheckAllDirections(List<IChessPiece> MyList, List<IChessPiece> EnemyList, IChessPiece Piece, List<MovementOptions> AllLegalMovesForThisPiece)
        {
            for (int direction = 0; direction < Piece.AllMoveOptionsForThisPiece.Count; direction++)
            {
                Piece.ClearMovementoptions();
                Piece.MoveOption(Piece.teamDirection);

                CheckLengthInDirection(MyList, EnemyList, Piece, AllLegalMovesForThisPiece, direction);
            }
        }
        //Chechs how far the current piece is allowed to move in the allowed directions. 
        private void CheckLengthInDirection(List<IChessPiece> MyList, List<IChessPiece> EnemyList, IChessPiece Piece, List<MovementOptions> AllLegalMovesForThisPiece, int direction)
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
                friendlyAhead = CheckIfFriendlyAhead(FuturePositionX, FuturePositionY, MyList);
                enemyAhead = CheckIfEnemyAhead(FuturePositionX, FuturePositionY, EnemyList);

                walkingLength = GameRules.CheckIfLegalMove(Piece, AllLegalMovesForThisPiece, direction, walkingLength, outOfBounds, friendlyAhead, enemyAhead, FuturePositionX, FuturePositionY);
            }
        }

        public static int CreateMovementOption(IChessPiece Piece, List<MovementOptions> AllLegalMovesForThisPiece, int direction, int walkingLength, bool enemyAhead, int FuturePositionX, int FuturePositionY)
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

        private bool CheckIfEnemyAhead(int FuturePositionX, int FuturePositionY, List<IChessPiece> EnemyPiecePositions)
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

        public bool CheckIfFriendlyAhead(int futureX, int futureY, List<IChessPiece> friendyPieces)
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

        public int GetRandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(min, max);
            return randomNumber;
        }
    }
}
