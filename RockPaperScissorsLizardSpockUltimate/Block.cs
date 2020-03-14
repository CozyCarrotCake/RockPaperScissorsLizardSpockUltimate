using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Block : Special
    {
        public Block()
        {
            name = "Block";

            againstRock = 0;
            againstPaper = 0;
            againstScissors = 0;
            againstLizard = 0;
            againstSpock = 0;

            damage = 0;
            defense = 100;
            combo = 0;
            criticalHit = 0;
        }
    }
}
