//Skeleton Program code for the AQA A Level Paper 1 Summer 2023 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

namespace Dastan
{
    class Player
    {
        private string Name;
        private int Direction, Score;
        private MoveOptionQueue Queue = new MoveOptionQueue();
        private bool SahmUsed;

        public Player(string N, int D)
        {
            Score = 100;
            Name = N;
            Direction = D;
            SahmUsed = false;
        }

        public bool SameAs(Player APlayer)
        {
            if (APlayer == null)
            {
                return false;
            }
            else if (APlayer.GetName() == Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Task 8
        public bool GetSahmStatus()
        {
            return SahmUsed;
        }
        public void SetSahmUsed(bool input)
        {
            SahmUsed = input;
        }
        public bool ChoiceIsSahm(MoveOption move)
        {
            if(move.GetName() == "sahm")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public MoveOptionQueue GetMoveOptionQueue()
        {
            return Queue;
        }

        public string GetPlayerStateAsString()
        {
            return Name + Environment.NewLine + "Score: " + Score.ToString() + Environment.NewLine + "Move option queue: " + Queue.GetQueueAsString() + Environment.NewLine;
        }

        public void AddToMoveOptionQueue(MoveOption NewMoveOption)
        {
            Queue.Add(NewMoveOption);
        }

        public void UpdateQueueAfterMove(int Position)
        {
            Queue.MoveItemToBack(Position - 1);
        }

        public void UpdateMoveOptionQueueWithOffer(int Position, MoveOption NewMoveOption)
        {
            Queue.Replace(Position, NewMoveOption);
        }

        public int GetScore()
        {
            return Score;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetDirection()
        {
            return Direction;
        }

        public void ChangeScore(int Amount)
        {
            Score += Amount;
        }

        public bool CheckPlayerMove(int Pos, int StartSquareReference, int FinishSquareReference)
        {
            MoveOption Temp = Queue.GetMoveOptionInPosition(Pos - 1);
            return Temp.CheckIfThereIsAMoveToSquare(StartSquareReference, FinishSquareReference);
        }


    }
}
