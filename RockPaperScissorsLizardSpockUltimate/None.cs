using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class None : Attack
    {

        public None()
        {
            name = "None";

            againstRock = -2;
            againstPaper = -2;
            againstScissors = -2;
            againstLizard = -2;
            againstSpock = -2;

            damage = 0;
            defense = 0;
            combo = 0;
            criticalHit = 0;
        }
    }
}
