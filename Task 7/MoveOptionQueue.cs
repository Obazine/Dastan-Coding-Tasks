//Skeleton Program code for the AQA A Level Paper 1 Summer 2023 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

namespace Dastan
{
    class MoveOptionQueue
    {
        private List<MoveOption> Queue = new List<MoveOption>();

        public string GetQueueAsString()
        {
            string QueueAsString = "";
            int Count = 1;
            foreach (var M in Queue)
            {
                QueueAsString += Count.ToString() + ". " + M.GetName() + "   ";
                Count += 1;
            }
            return QueueAsString;
        }

        public void Add(MoveOption NewMoveOption)
        {
            Queue.Add(NewMoveOption);
        }

        public void Replace(int Position, MoveOption NewMoveOption)
        {
            Queue[Position] = NewMoveOption;
        }

        public void MoveItemToBack(int Position)
        {
            MoveOption Temp = Queue[Position];
            Queue.RemoveAt(Position);
            Queue.Add(Temp);
        }

        public MoveOption GetMoveOptionInPosition(int Pos)
        {
            return Queue[Pos];
        }

        //Task 7
        public void ResetQueueBack(int Position)
        {
            for (int i = Position-1; i<4; i++)
            {
                MoveItemToBack(i);
            }
        }
    }
}
