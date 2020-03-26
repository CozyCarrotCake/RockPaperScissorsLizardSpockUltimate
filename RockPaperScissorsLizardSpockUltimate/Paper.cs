using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Paper : Attack
    {
        public Paper()
        {
            name = "Paper";

            againstRock = 1;
            againstPaper = 0;
            againstScissors = 0;
            againstLizard = 0;
            againstSpock = 1;


            damage = 30;
            defense = 50;
            combo = 1.25;
            criticalHit = 30;
        }


        public override void Transform()
        {
            firstTransform = new TraTree();
            secondTransform = new TraBoi();
        }
    }
}
