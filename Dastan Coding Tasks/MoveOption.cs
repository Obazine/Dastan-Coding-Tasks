//Skeleton Program code for the AQA A Level Paper 1 Summer 2023 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

namespace Dastan
{
    class MoveOption
    {
        protected string Name;
        protected List<Move> PossibleMoves;

        public MoveOption(string N)
        {
            Name = N;
            PossibleMoves = new List<Move>();
        }

        public void AddToPossibleMoves(Move M)
        {
            PossibleMoves.Add(M);
        }

        public string GetName()
        {
            return Name;
        }

        public bool CheckIfThereIsAMoveToSquare(int StartSquareReference, int FinishSquareReference)
        {
            int StartRow = StartSquareReference / 10;
            int StartColumn = StartSquareReference % 10;
            int FinishRow = FinishSquareReference / 10;
            int FinishColumn = FinishSquareReference % 10;
            foreach (var M in PossibleMoves)
            {
                if (StartRow + M.GetRowChange() == FinishRow && StartColumn + M.GetColumnChange() == FinishColumn)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
