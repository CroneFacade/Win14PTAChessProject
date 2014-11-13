using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTAChessProjectCode
{
    public class MoveData
    {
        private AI AIToMove { get; set; }
        private AI AINotToMove { get; set; }
        //private List<ChessPiece> EnemyAIPieces { get; set; }
        public List<ChessPiece> PieceThatCanMove { get; set; }
        public List<ChessPiece> PieceThatCanKill { get; set; }

        public List<ChessPiece> EnemyPiecePositions { get; set; }
        public List<string> AllMoves { get; set; }

        public MoveData(AI playerToMove, AI playerNotToMove)
        {
            this.AIToMove = playerToMove;
            this.AINotToMove = playerNotToMove;
            this.EnemyPiecePositions = playerNotToMove.PieceList;
            AllMoves = new List<string>();
            PieceThatCanMove = new List<ChessPiece>();
            PieceThatCanKill = new List<ChessPiece>();
        }

        public List<ChessPiece> MakeMove(AI playerToMove)
        {
            SetNewAIToMakeMove(playerToMove);

            List<ChessPiece> AfterMoveList = AIMakeMove(AIToMove);
            return AfterMoveList;
        }

        private void SetNewAIToMakeMove(AI playerToMove)
        {
            this.AIToMove = playerToMove;
        }

        public List<ChessPiece> AIMakeMove(AI AIToMove)
        {
            //ClearTempLists(PieceThatCanMove);
            //ClearTempLists(PieceThatCanKill);

            List<List<MovementOptions>> AllMovesMyPiecesCanMake = AnalyzeMyPieces(AIToMove.PieceList);

            List<MovementOptions> PiecesICanKill = FindPiecesICanKill(AllMovesMyPiecesCanMake);

            var rnd = new Random();

            int random1 = rnd.Next(0,AllMovesMyPiecesCanMake.Count);

            int TempTest = AllMovesMyPiecesCanMake[random1].Count;

            System.Threading.Thread.Sleep(100);

            int random2 = rnd.Next(0,TempTest);

            MovementOptions MoveTempTest = AllMovesMyPiecesCanMake[random1][random2];


            //MovementOptions pieceToMove = PickPiece(AIToMove.PieceList);
            //string Coordinates = GetCoordinates(pieceToMove);
            List<ChessPiece> NewList = MovePiece(MoveTempTest, AIToMove.PieceList, EnemyPiecePositions);
            return NewList;
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

        private List<ChessPiece> MovePiece(MovementOptions pieceToMove, List<ChessPiece> list, List<ChessPiece> EnemyPiecePositions)
        {
            foreach (var MyPiece in list)
            {
                if (pieceToMove.IDOfMyPiece == MyPiece.id)
                {
                    MyPiece.PositionX = pieceToMove.PositionX;
                    MyPiece.PositionY = pieceToMove.PositionY;
                    //this.EnemyPiecePositions = RemoveEnemyPiece(EnemyPiecePositions, MyPiece.PositionX, MyPiece.PositionY);
                    return list;
                }
            }
            return list;
        }

        private List<ChessPiece> RemoveEnemyPiece(List<ChessPiece> EnemyPiecePositions, int x, int y)
        {
            foreach (var piece in EnemyPiecePositions)
            {
                if (piece.PositionX == x && piece.PositionY == y)
                {
                    EnemyPiecePositions.Remove(piece);
                    return EnemyPiecePositions;
                }
            }
            return EnemyPiecePositions;
        }

        private List<List<MovementOptions>> AnalyzeMyPieces(List<ChessPiece> list)
        {
            var AllMoves = new List<List<MovementOptions>>();
            foreach (var Piece in list)
            {
                Piece.ClearMovementoptions();
                Piece.MoveOption(Piece.teamDirection);
               
                var AllLegalMovesForThisPiece = new List<MovementOptions>();

                for (int z = 0; z < Piece.AllMoveOptionsForThisPiece.Count; z++)
			{
			
                    Piece.ClearMovementoptions();
                    Piece.MoveOption(Piece.teamDirection);
			
                for (int i = 1; i <= Piece.AllMoveOptionsForThisPiece[z].WalkingLength; i++)
			{
                    var outOfBounds = false;
                    var friendlyAhead = false;
                    var enemyAhead = false;
                    
                    int Walkinglength = i;

                    Piece.ClearMovementoptions();
                    Piece.MoveOption(Piece.teamDirection);


                    int MovingPositionX = Piece.AllMoveOptionsForThisPiece[z].PositionX * Walkinglength;
                    int MovingPositionY = Piece.AllMoveOptionsForThisPiece[z].PositionY * Walkinglength;

                    int FuturePositionX = Piece.PositionX + MovingPositionX;
                    int FuturePositionY = Piece.PositionY + MovingPositionY;

                    outOfBounds = CheckIfOutOfBounds(FuturePositionX, FuturePositionY);
                    friendlyAhead = CheckIfFriendlyAhead(FuturePositionX, FuturePositionY, list);
                    enemyAhead = CheckIfEnemyAhead(FuturePositionX, FuturePositionY, EnemyPiecePositions);

                    if (!outOfBounds && !friendlyAhead)
                        {

                            MovementOptions MoveChoice = Piece.AllMoveOptionsForThisPiece[z];

                            MoveChoice.MyPiece = Piece;

                            if (enemyAhead)
                            {
                                MoveChoice.CheckForEnemyResult = 1;
                            }
                            
                            Piece.AllMoveOptionsForThisPiece[z].PositionX = FuturePositionX;
                            Piece.AllMoveOptionsForThisPiece[z].PositionY = FuturePositionY;
                            AllLegalMovesForThisPiece.Add(Piece.AllMoveOptionsForThisPiece[z]);
                            Piece.AllMoveOptionsForThisPiece[z] = MoveChoice;
                        }
                    else
                        {
                        i = 100;
                        }
                    
		     }
                 
                }

                if (AllLegalMovesForThisPiece.Count != 0)
                {
                        AllMoves.Add(AllLegalMovesForThisPiece);
               }
            }

            
            
            return AllMoves;
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

        //De pjäser som inte kan rör sig tas bort ur listan PieceThatCanMove, har testkört och sett att det fungerar. 
        //Endast de pjäser som fortfarande har drag kvar återstår i listan.
        private void ClearTempLists(List<ChessPiece> PieceThatCanMove)
        {
            PieceThatCanMove.Clear();
        }
        //test
        private void CalculatePieceMovement(List<ChessPiece> PieceList)
        {
            foreach (var piece in PieceList)
            {
               // piece.TurnAvailableMoves = new List<List<string>>();
                //piece.TurnAvailableMoves = new List<MovementOptions>();

                

                //List<string> coordinates = new List<string>();



                

                    //string[] getDirectionX = directions.Split(',');
                    //string[] getDirectionYAndLength = getDirectionX[1].Split('.');

                    //var addX = int.Parse(getDirectionX[0]);
                    //var addY = int.Parse(getDirectionYAndLength[0]);
                    //var pieceMovementLength = int.Parse(getDirectionYAndLength[1]);

                    

                    
                }

                // Check if there is a coordinate to add. If there is, add the piece movements to list TurnAvailableMoves
                // This statement prevents the app to crash if a piece cannot move but is choosen to try to move.
                // As the piece that cannot move do not contain a "TurnAvailableMoves" list, another piece is picked.


                //TODO: ska en ny lista som innehåller alla pjäser som kan gå åt ett håll.
                // om ingen riktning sparas, lägg till i ny lista:
            }



        public bool CheckIfOutOfBounds(int futureX, int futureY)
        {
            if (((futureX > -1) && (futureX < 8)) && ((futureY > -1) && (futureY < 8)))
            {
                return false;
            }
            /*OOBCounter++;
            Console.SetCursorPosition(20, 18);
            Console.WriteLine("Out Of Bounds tries {0}", OOBCounter);*/
            return true;
        }

        public bool CheckIfFriendlyAhead(int futureX, int futureY, List<ChessPiece> friendyPieces)
        {

            foreach (var piece in friendyPieces)
            {

                if ((futureX == piece.PositionX) && (futureY == piece.PositionY))
                {
                    /*count++;
                    Console.SetCursorPosition(20, 16);
                    Console.WriteLine("Friendly piece in the way {0} times", count);
                    System.Threading.Thread.Sleep(100);*/
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

        public int GetRandomNumber(List<string> coords)
        {
            Random rnd = new Random();
            int max = coords.Count + 1;
            int min = 1;
            int randomNumber = rnd.Next(min, max);
            return randomNumber - 1;
        }


        public int GetRandomNumber(List<ChessPiece> pieces)
        {
            Random rnd = new Random();
            int max = pieces.Count + 1;
            int min = 1;
            int randomNumber = rnd.Next(min, max);
            return randomNumber - 1;
        }

        //public string GetCoordinates(ChessPiece pieceToMove)
        //{
        //    string Coords;


        //        int randNumber = GetRandomNumber(pieceToMove.TurnAvailableMoves[0]);
        //        Coords = pieceToMove.TurnAvailableMoves[0][randNumber];

        //    return Coords;
        //}

        public void MovePiece(ChessPiece pieceToMove, string coordinates)
        {
            /* Console.SetCursorPosition(0, 17);
             Console.WriteLine(pieceToMove.Name);
             foreach (var item in pieceToMove.TurnAvailableMoves[0][0])
             {
                
                 Console.WriteLine(item);
             }
             Console.ReadLine();*/


            string[] newCoordX = coordinates.Split(',');
            string[] newCoordY = newCoordX[1].Split('.');
            int newX = int.Parse(newCoordX[0]);
            int newY = int.Parse(newCoordY[0]);

            Console.SetCursorPosition(pieceToMove.PositionX, pieceToMove.PositionY);
            Console.Write(" ");
            pieceToMove.PositionX = newX;
            pieceToMove.PositionY = newY;

            Console.SetCursorPosition(pieceToMove.PositionX, pieceToMove.PositionY);
            Console.Write(pieceToMove.Name);
            System.Threading.Thread.Sleep(100);

            foreach (var piece in AIToMove.PieceList)
            {
                var tempx = piece.PositionX;
                var tempy = piece.PositionY;

                foreach (var item in AIToMove.PieceList)
                {
                    if (piece != item)
                    {
                        if (item.PositionX == tempx && item.PositionY == tempy)
                        {

                            /*countSameTile++;
                            Console.SetCursorPosition(20, 20);
                            Console.WriteLine("Same tile {0}.", countSameTile);
                            Console.ReadLine();*/
                            //System.Threading.Thread.Sleep(5000);
                        }
                    }
                }
            }

            foreach (var piece in AIToMove.PieceList)
            {
                piece.TurnAvailableMoves.Clear();
            }

        }
    }
}
