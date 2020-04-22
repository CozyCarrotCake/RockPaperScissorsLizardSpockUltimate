using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Spock : Attack
    {
        public Spock()
        {
            name = "Spock";

            againstRock = 1;
            againstPaper = 0;
            againstScissors = 1;
            againstLizard = 0;
            againstSpock = 0;

            damage = 70;
            defense = 70;
            combo = 1.12;
            criticalHit = 15;
        }

        public override void Transform()
        {
            base.Transform();
            firstTransform = new TraGun();
            secondTransform = new TraKhaaan();
        }
    }
}
