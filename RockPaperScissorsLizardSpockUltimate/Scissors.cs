using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Scissors : Attack
    {
        public Scissors()
        {
            name = "Scissors";

            againstRock = 0;
            againstPaper = 1;
            againstScissors = 0;
            againstLizard = 1;
            againstSpock = 0;

            
            damage = 70;
            defense = 30;
            combo = 1.17;
            criticalHit = 25;
        }

        public override void Transform()
        {
            firstTransform = new TraEdward();
            secondTransform = new TraEyeStabber();
        }


    }
}
