using Dastan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12
{
    class Barrier :Square
    {
        public Barrier(Player player)
        {
            if(player.GetDirection() == 1)
            {
                Symbol = "B";
            }
            else
            {
                Symbol = "b";
            }
        }

        
    }
}
