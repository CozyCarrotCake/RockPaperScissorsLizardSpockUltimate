using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Snap : Special
    {
        public Snap()
        {
            name = "Snap";

            againstRock = 3;
            againstPaper = 3;
            againstScissors = 3;
            againstLizard = 3;
            againstSpock = 3;

            damage = 100;
            defense = 0;
            combo = 1.2;
            criticalHit = 1;
        }
    }
}
