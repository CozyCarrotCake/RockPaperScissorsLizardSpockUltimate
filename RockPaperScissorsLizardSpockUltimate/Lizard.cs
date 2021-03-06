﻿using System;
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

            againstRock = 0;
            againstPaper = 1;
            againstScissors = 0;
            againstLizard = 0;
            againstSpock = 1;

            damage = 60;
            defense = 40;
            combo = 1.3;
            criticalHit = 10;
        }

        public override void Transform()
        {
            base.Transform();
            firstTransform = new TraDragon();
            secondTransform = new TraTurtle();
        }

    }
}
