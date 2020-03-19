using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Rock : Attack
    {


        public Rock()
        {
            name = "Rock";

            againstRock = 0;
            againstPaper = -1;
            againstScissors = 1;
            againstLizard = 1;
            againstSpock = -1;

            damage = 80;
            defense = 90;
            combo = 1.15;
            criticalHit = 15;
        }


        


    }
}
