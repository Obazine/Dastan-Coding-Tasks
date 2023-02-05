//Skeleton Program code for the AQA A Level Paper 1 Summer 2023 examination
//this code should be used in conjunction with the Preliminary Material
//written by the AQA Programmer Team
//developed in the Visual Studio Community Edition programming environment

namespace Dastan
{
    class Square
    {
        protected string Symbol;
        protected Piece PieceInSquare;
        protected Player BelongsTo;

        public Square()
        {
            PieceInSquare = null;
            BelongsTo = null;
            Symbol = " ";
        }

        public virtual void SetPiece(Piece P)
        {
            PieceInSquare = P;
        }

        public virtual Piece RemovePiece()
        {
            Piece PieceToReturn = PieceInSquare;
            PieceInSquare = null;
            return PieceToReturn;
        }

        public virtual Piece GetPieceInSquare()
        {
            return PieceInSquare;
        }

        public virtual string GetSymbol()
        {
            return Symbol;
        }

        public virtual int GetPointsForOccupancy(Player CurrentPlayer)
        {
            return 0;
        }

        public virtual Player GetBelongsTo()
        {
            return BelongsTo;
        }

        public virtual bool ContainsKotla()
        {
            if (Symbol == "K" || Symbol == "k")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
