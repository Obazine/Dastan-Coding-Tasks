//Skeleton Program code for the AQA A Level Paper 1 Summer 2023 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

namespace Dastan
{
    class Move
    {
        protected int RowChange, ColumnChange;

        public Move(int R, int C)
        {
            RowChange = R;
            ColumnChange = C;
        }

        public int GetRowChange()
        {
            return RowChange;
        }

        public int GetColumnChange()
        {
            return ColumnChange;
        }
    }
}
