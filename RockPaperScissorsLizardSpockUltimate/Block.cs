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
            name = "Block"; // isa shit

            againstRock = 1;
            againstPaper = 1;
            againstScissors = 1;
            againstLizard = 1;
            againstSpock = 1;

            damage = 0;
            defense = 100;
            combo = 0;
            criticalHit = 0;
        }
    }
}
