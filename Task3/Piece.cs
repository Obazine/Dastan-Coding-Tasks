//Skeleton Program code for the AQA A Level Paper 1 Summer 2023 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

namespace Dastan
{
    class Piece
    {
        protected string TypeOfPiece, Symbol;
        protected int PointsIfCaptured;
        protected Player BelongsTo;

        public Piece(string T, Player B, int P, string S)
        {
            TypeOfPiece = T;
            BelongsTo = B;
            PointsIfCaptured = P;
            Symbol = S;
        }

        public string GetSymbol()
        {
            return Symbol;
        }

        public string GetTypeOfPiece()
        {
            return TypeOfPiece;
        }

        public Player GetBelongsTo()
        {
            return BelongsTo;
        }

        public int GetPointsIfCaptured()
        {
            return PointsIfCaptured;
        }
    }
}
