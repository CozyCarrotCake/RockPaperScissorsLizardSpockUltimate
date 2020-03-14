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

            againstRock = 1;
            againstPaper = 1;
            againstScissors = 1;
            againstLizard = 1;
            againstSpock = 1;

            damage = 100;
            defense = 0;
            combo = 0.2;
            criticalHit = 0.01;
        }
    }
}
