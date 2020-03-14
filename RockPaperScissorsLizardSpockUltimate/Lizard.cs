using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Lizard : Attack
    {
        public Lizard()
        {
            name = "Lizard";

            againstRock = -1;
            againstPaper = 1;
            againstScissors = -1;
            againstLizard = 0;
            againstSpock = 1;

            damage = 60;
            defense = 40;
            combo = 0.3;
            criticalHit = 0.1;
        }

    }
}
