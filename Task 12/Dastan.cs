//Skeleton Program code for the AQA A Level Paper 1 Summer 2023 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment
using Task_12;
using Barrier = Task_12.Barrier;

namespace Dastan
{
    class Dastan
    {
        protected List<Square> Board;
        protected int NoOfRows, NoOfColumns, MoveOptionOfferPosition;
        protected List<Player> Players = new List<Player>();
        protected List<string> MoveOptionOffer = new List<string>();
        protected Player CurrentPlayer;
        protected Random RGen = new Random();

        public Dastan(int R, int C, int NoOfPieces)
        {
            Players.Add(new Player("Player 1", 1));
            Players.Add(new Player("Player 2", -1));
            CreateMoveOptions();
            NoOfRows = R;
            NoOfColumns = C;
            MoveOptionOfferPosition = 0;
            CreateMoveOptionOffer();
            CreateBoard();
            CreatePieces(NoOfPieces);
            CurrentPlayer = Players[0];
        }

        private void DisplayBoard()
        {
            Console.Write(Environment.NewLine + "   ");
            for (int Column = 1; Column <= NoOfColumns; Column++)
            {
                Console.Write(Column.ToString() + "  ");
            }
            Console.Write(Environment.NewLine + "  ");
            for (int Count = 1; Count <= NoOfColumns; Count++)
            {
                Console.Write("---");
            }
            Console.WriteLine("-");
            for (int Row = 1; Row <= NoOfRows; Row++)
            {
                Console.Write(Row.ToString() + " ");
                for (int Column = 1; Column <= NoOfColumns; Column++)
                {
                    int Index = GetIndexOfSquare(Row * 10 + Column);
                    Console.Write("|" + Board[Index].GetSymbol());
                    Piece PieceInSquare = Board[Index].GetPieceInSquare();
                    if (PieceInSquare == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(PieceInSquare.GetSymbol());
                    }
                }
                Console.WriteLine("|");
            }
            Console.Write("  -");
            for (int Column = 1; Column <= NoOfColumns; Column++)
            {
                Console.Write("---");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private void DisplayState()
        {
            DisplayBoard();
            Console.WriteLine("Move option offer: " + MoveOptionOffer[MoveOptionOfferPosition]);
            Console.WriteLine();
            Console.WriteLine(CurrentPlayer.GetPlayerStateAsString());
            Console.WriteLine("Turn: " + CurrentPlayer.GetName());
            Console.WriteLine();
        }

        private int GetIndexOfSquare(int SquareReference)
        {
            int Row = SquareReference / 10;
            int Col = SquareReference % 10;
            return (Row - 1) * NoOfColumns + (Col - 1);
        }

        private bool CheckSquareInBounds(int SquareReference)
        {
            int Row = SquareReference / 10;
            int Col = SquareReference % 10;
            if (Row < 1 || Row > NoOfRows)
            {
                return false;
            }
            else if (Col < 1 || Col > NoOfColumns)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckSquareIsValid(int SquareReference, bool StartSquare)
        {
            if (!CheckSquareInBounds(SquareReference))
            {
                return false;
            }
            Piece PieceInSquare = Board[GetIndexOfSquare(SquareReference)].GetPieceInSquare();
            //taask 12
            if (Board[GetIndexOfSquare(SquareReference)].ContainsBarrier())
            {
                return false;
            }
            if (PieceInSquare == null)
            {
                if (StartSquare)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (CurrentPlayer.SameAs(PieceInSquare.GetBelongsTo()))
            {
                if (StartSquare)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (StartSquare)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //Task 12
        private bool CheckBarrierIsValid(int SquareReference)
        {
            for(int i = SquareReference - 1; i< SquareReference + 2; i++)
            {
                if(!CheckSquareIsValid(i, false))
                {
                    return false;
                }
            }
            return true;
        }
        private void PlaceBarrier(int SquareReference, Player player)
        {
            if(CheckBarrierIsValid(SquareReference))
            {
                for (int i = SquareReference - 1; i < SquareReference + 2; i++)
                {
                    Board[GetIndexOfSquare(i)] = new Barrier(player);
                }
            }
        }
        private bool CheckManhattanDistance(int Choice, int StartSquareReference, int FinishSquareReference)
        {
            if(!CurrentPlayer.CheckPlayerMove(Choice, StartSquareReference, FinishSquareReference))
            {
                return false;
            }
            else
            {
                int VerticalDistance = (FinishSquareReference / 10 - StartSquareReference / 10);
                int HorizontalDistance = (FinishSquareReference % 10 - StartSquareReference % 10);
                bool Result = true;
                for (int i = 0; i < Math.Abs(VerticalDistance); i++)
                {
                    int Reference = StartSquareReference + VerticalDistance * 10 - (i * 10 * (VerticalDistance / Math.Abs(VerticalDistance)));
                    if (Board[GetIndexOfSquare(Reference)].GetSymbol() == "B" || Board[GetIndexOfSquare(Reference)].GetSymbol() == "b") 
                    {
                        Result = false;
                        break;
                    }
                }
                for (int i = 0; i < Math.Abs(HorizontalDistance); i++)
                {
                    int Reference = FinishSquareReference - HorizontalDistance + (i * (HorizontalDistance / Math.Abs(HorizontalDistance)));
                    if (Board[GetIndexOfSquare(Reference)].GetSymbol() == "B" || Board[GetIndexOfSquare(Reference)].GetSymbol() == "b")
                    {
                        Result = false;
                        break;
                    }
                }

                bool Result2 = true;
                for (int i = 0; i < Math.Abs(VerticalDistance); i++)
                {
                    int Reference = FinishSquareReference - VerticalDistance * 10 + (i * 10 * (VerticalDistance / Math.Abs(VerticalDistance))); 
                    if (Board[GetIndexOfSquare(Reference)].GetSymbol() == "B" || Board[GetIndexOfSquare(Reference)].GetSymbol() == "b")
                    {
                        Result2 = false;
                        break;
                    }
                }
                for (int i = 0; i < Math.Abs(HorizontalDistance); i++)
                {
                    int Reference = StartSquareReference + HorizontalDistance - (i * (HorizontalDistance / Math.Abs(HorizontalDistance)));
                    if (Board[GetIndexOfSquare(Reference)].GetSymbol() == "B" || Board[GetIndexOfSquare(Reference)].GetSymbol() == "b")
                    {
                        Result2 = false;
                        break;
                    }
                }
                if (Result2 || Result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool CheckIfGameOver()
        {
            bool Player1HasMirza = false;
            bool Player2HasMirza = false;
            foreach (var S in Board)
            {
                Piece PieceInSquare = S.GetPieceInSquare();
                if (PieceInSquare != null)
                {
                    if (S.ContainsKotla() && PieceInSquare.GetTypeOfPiece() == "mirza" && !PieceInSquare.GetBelongsTo().SameAs(S.GetBelongsTo()))
                    {
                        return true;
                    }
                    else if (PieceInSquare.GetTypeOfPiece() == "mirza" && PieceInSquare.GetBelongsTo().SameAs(Players[0]))
                    {
                        Player1HasMirza = true;
                    }
                    else if (PieceInSquare.GetTypeOfPiece() == "mirza" && PieceInSquare.GetBelongsTo().SameAs(Players[1]))
                    {
                        Player2HasMirza = true;
                    }
                }
            }
            return !(Player1HasMirza && Player2HasMirza);
        }

        private int GetSquareReference(string Description)
        {
            int SelectedSquare;
            Console.Write("Enter the square " + Description + " (row number followed by column number): ");
            SelectedSquare = Convert.ToInt32(Console.ReadLine());
            return SelectedSquare;
        }

        private void UseMoveOptionOffer()
        {
            int ReplaceChoice;
            Console.Write("Choose the move option from your queue to replace (1 to 5): ");
            ReplaceChoice = Convert.ToInt32(Console.ReadLine());
            CurrentPlayer.UpdateMoveOptionQueueWithOffer(ReplaceChoice - 1, CreateMoveOption(MoveOptionOffer[MoveOptionOfferPosition], CurrentPlayer.GetDirection()));
            CurrentPlayer.ChangeScore(-(10 - (ReplaceChoice * 2)));
            MoveOptionOfferPosition = RGen.Next(0, 5);
        }

        private int GetPointsForOccupancyByPlayer(Player CurrentPlayer)
        {
            int ScoreAdjustment = 0;
            foreach (var S in Board)
            {
                ScoreAdjustment += (S.GetPointsForOccupancy(CurrentPlayer));
            }
            return ScoreAdjustment;
        }

        private void UpdatePlayerScore(int PointsForPieceCapture)
        {
            CurrentPlayer.ChangeScore(GetPointsForOccupancyByPlayer(CurrentPlayer) + PointsForPieceCapture);
        }

        private int CalculatePieceCapturePoints(int FinishSquareReference)
        {
            if (Board[GetIndexOfSquare(FinishSquareReference)].GetPieceInSquare() != null)
            {
                return Board[GetIndexOfSquare(FinishSquareReference)].GetPieceInSquare().GetPointsIfCaptured();
            }
            return 0;
        }

        public void PlayGame()
        {
            bool GameOver = false;
            int SquareReference;
            do
            {
                Console.WriteLine("Player 1, Please enter where you would like to place the barrier... ");
                SquareReference = Convert.ToInt32(Console.ReadLine());
            } while (!CheckBarrierIsValid(SquareReference));
            PlaceBarrier(SquareReference, Players[0]);
            int SquareReference2;
            do
            {
                Console.WriteLine("Player 2, Please enter where you would like to place the barrier... ");
                SquareReference2 = Convert.ToInt32(Console.ReadLine());
            } while (!CheckBarrierIsValid(SquareReference2));
            PlaceBarrier(SquareReference2, Players[1]);

            while (!GameOver)
            {
                DisplayState();
                bool SquareIsValid = false;
                int Choice;
                do
                {
                    Console.Write("Choose move option to use from queue (1 to 3) or 9 to take the offer: ");
                    Choice = Convert.ToInt32(Console.ReadLine());
                    if (Choice == 9)
                    {
                        UseMoveOptionOffer();
                        DisplayState();
                    }
                }
                while (Choice < 1 || Choice > 3);
                int StartSquareReference = 0;
                while (!SquareIsValid)
                {
                    StartSquareReference = GetSquareReference("containing the piece to move");
                    SquareIsValid = CheckSquareIsValid(StartSquareReference, true);
                }
                int FinishSquareReference = 0;
                SquareIsValid = false;
                while (!SquareIsValid)
                {
                    FinishSquareReference = GetSquareReference("to move to");
                    SquareIsValid = CheckSquareIsValid(FinishSquareReference, false);
                }
                bool MoveLegal = CheckManhattanDistance(Choice, StartSquareReference, FinishSquareReference);
                if (MoveLegal)
                {
                    int PointsForPieceCapture = CalculatePieceCapturePoints(FinishSquareReference);
                    CurrentPlayer.ChangeScore(-(Choice + (2 * (Choice - 1))));
                    CurrentPlayer.UpdateQueueAfterMove(Choice);
                    UpdateBoard(StartSquareReference, FinishSquareReference);
                    UpdatePlayerScore(PointsForPieceCapture);
                    Console.WriteLine("New score: " + CurrentPlayer.GetScore() + Environment.NewLine);
                }
                if (CurrentPlayer.SameAs(Players[0]))
                {
                    CurrentPlayer = Players[1];
                }
                else
                {
                    CurrentPlayer = Players[0];
                }
                GameOver = CheckIfGameOver();
            }
            DisplayState();
            DisplayFinalResult();
        }

        private void UpdateBoard(int StartSquareReference, int FinishSquareReference)
        {
            Board[GetIndexOfSquare(FinishSquareReference)].SetPiece(Board[GetIndexOfSquare(StartSquareReference)].RemovePiece());
        }

        private void DisplayFinalResult()
        {
            if (Players[0].GetScore() == Players[1].GetScore())
            {
                Console.WriteLine("Draw!");
            }
            else if (Players[0].GetScore() > Players[1].GetScore())
            {
                Console.WriteLine(Players[0].GetName() + " is the winner!");
            }
            else
            {
                Console.WriteLine(Players[1].GetName() + " is the winner!");
            }
        }

        private void CreateBoard()
        {
            Square S;
            Board = new List<Square>();
            for (int Row = 1; Row <= NoOfRows; Row++)
            {
                for (int Column = 1; Column <= NoOfColumns; Column++)
                {
                    if (Row == 1 && Column == NoOfColumns / 2)
                    {
                        S = new Kotla(Players[0], "K");
                    }
                    else if (Row == NoOfRows && Column == NoOfColumns / 2 + 1)
                    {
                        S = new Kotla(Players[1], "k");
                    }
                    else
                    {
                        S = new Square();
                    }
                    Board.Add(S);
                }
            }
        }

        private void CreatePieces(int NoOfPieces)
        {
            Piece CurrentPiece;
            for (int Count = 1; Count <= NoOfPieces; Count++)
            {
                CurrentPiece = new Piece("piece", Players[0], 1, "!");
                Board[GetIndexOfSquare(2 * 10 + Count + 1)].SetPiece(CurrentPiece);
            }
            CurrentPiece = new Piece("mirza", Players[0], 5, "1");
            Board[GetIndexOfSquare(10 + NoOfColumns / 2)].SetPiece(CurrentPiece);
            for (int Count = 1; Count <= NoOfPieces; Count++)
            {
                CurrentPiece = new Piece("piece", Players[1], 1, "\"");
                Board[GetIndexOfSquare((NoOfRows - 1) * 10 + Count + 1)].SetPiece(CurrentPiece);
            }
            CurrentPiece = new Piece("mirza", Players[1], 5, "2");
            Board[GetIndexOfSquare(NoOfRows * 10 + (NoOfColumns / 2 + 1))].SetPiece(CurrentPiece);
        }

        private void CreateMoveOptionOffer()
        {
            MoveOptionOffer.Add("jazair");
            MoveOptionOffer.Add("chowkidar");
            MoveOptionOffer.Add("cuirassier");
            MoveOptionOffer.Add("ryott");
            MoveOptionOffer.Add("faujdar");
        }

        private MoveOption CreateRyottMoveOption(int Direction)
        {
            MoveOption NewMoveOption = new MoveOption("ryott");
            Move NewMove = new Move(0, 1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(0, -1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(1 * Direction, 0);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(-1 * Direction, 0);
            NewMoveOption.AddToPossibleMoves(NewMove);
            return NewMoveOption;
        }

        private MoveOption CreateFaujdarMoveOption(int Direction)
        {
            MoveOption NewMoveOption = new MoveOption("faujdar");
            Move NewMove = new Move(0, -1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(0, 1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(0, 2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(0, -2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            return NewMoveOption;
        }

        private MoveOption CreateJazairMoveOption(int Direction)
        {
            MoveOption NewMoveOption = new MoveOption("jazair");
            Move NewMove = new Move(2 * Direction, 0);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(2 * Direction, -2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(2 * Direction, 2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(0, 2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(0, -2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(-1 * Direction, -1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(-1 * Direction, 1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            return NewMoveOption;
        }

        private MoveOption CreateCuirassierMoveOption(int Direction)
        {
            MoveOption NewMoveOption = new MoveOption("cuirassier");
            Move NewMove = new Move(1 * Direction, 0);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(2 * Direction, 0);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(1 * Direction, -2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(1 * Direction, 2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            return NewMoveOption;
        }

        private MoveOption CreateChowkidarMoveOption(int Direction)
        {
            MoveOption NewMoveOption = new MoveOption("chowkidar");
            Move NewMove = new Move(1 * Direction, 1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(1 * Direction, -1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(-1 * Direction, 1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(-1 * Direction, -1 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(0, 2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            NewMove = new Move(0, -2 * Direction);
            NewMoveOption.AddToPossibleMoves(NewMove);
            return NewMoveOption;
        }

        private MoveOption CreateMoveOption(string Name, int Direction)
        {
            if (Name == "chowkidar")
            {
                return CreateChowkidarMoveOption(Direction);
            }
            else if (Name == "ryott")
            {
                return CreateRyottMoveOption(Direction);
            }
            else if (Name == "faujdar")
            {
                return CreateFaujdarMoveOption(Direction);
            }
            else if (Name == "jazair")
            {
                return CreateJazairMoveOption(Direction);
            }
            else
            {
                return CreateCuirassierMoveOption(Direction);
            }
        }

        private void CreateMoveOptions()
        {
            Players[0].AddToMoveOptionQueue(CreateMoveOption("ryott", 1));
            Players[0].AddToMoveOptionQueue(CreateMoveOption("chowkidar", 1));
            Players[0].AddToMoveOptionQueue(CreateMoveOption("cuirassier", 1));
            Players[0].AddToMoveOptionQueue(CreateMoveOption("faujdar", 1));
            Players[0].AddToMoveOptionQueue(CreateMoveOption("jazair", 1));
            Players[1].AddToMoveOptionQueue(CreateMoveOption("ryott", -1));
            Players[1].AddToMoveOptionQueue(CreateMoveOption("chowkidar", -1));
            Players[1].AddToMoveOptionQueue(CreateMoveOption("jazair", -1));
            Players[1].AddToMoveOptionQueue(CreateMoveOption("faujdar", -1));
            Players[1].AddToMoveOptionQueue(CreateMoveOption("cuirassier", -1));
        }
    }
}
