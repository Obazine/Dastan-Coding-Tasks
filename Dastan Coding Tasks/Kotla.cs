//Skeleton Program code for the AQA A Level Paper 1 Summer 2023 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

namespace Dastan
{
    class Kotla : Square
    {
        public Kotla(Player P, string S) : base()
        {
            BelongsTo = P;
            Symbol = S;
        }

        public override int GetPointsForOccupancy(Player CurrentPlayer)
        {
            if (PieceInSquare == null)
            {
                return 0;
            }
            else if (BelongsTo.SameAs(CurrentPlayer))
            {
                if (CurrentPlayer.SameAs(PieceInSquare.GetBelongsTo()) && (PieceInSquare.GetTypeOfPiece() == "piece" || PieceInSquare.GetTypeOfPiece() == "mirza"))
                {
                    return 5;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (CurrentPlayer.SameAs(PieceInSquare.GetBelongsTo()) && (PieceInSquare.GetTypeOfPiece() == "piece" || PieceInSquare.GetTypeOfPiece() == "mirza"))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
