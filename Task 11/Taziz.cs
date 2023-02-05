using Dastan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11
{
    class Taziz : Square
    {
        protected int CampedTurns = 0;
        public Taziz(string symbol)
        {
            Symbol = symbol;
        }

        public override void SetPiece(Piece P)
        {
            if(P.GetBelongsTo().GetDirection() == 1)
            {
                Symbol = "A";
            }
            else
            {
                Symbol = "a";
            }
            BelongsTo = P.GetBelongsTo();
            CampedTurns = 0;
            base.SetPiece(P);
        }

        public override Piece RemovePiece()
        {
            BelongsTo = null;
            Symbol = "x";
            return base.RemovePiece();
        }

        public bool GetCampedTwoTurns()
        {
            if(CampedTurns == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckCamp(Player player)
        {
            if(player.GetDirection() == PieceInSquare.GetBelongsTo().GetDirection())
            {
                CampedTurns++;
            }
        }
    }
}
