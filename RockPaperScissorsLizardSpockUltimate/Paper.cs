﻿using System;
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
            againstScissors = -1;
            againstLizard = -1;
            againstSpock = 1;


            damage = 30;
            defense = 50;
            combo = 0.25;
            criticalHit = 0.30;
        }

    }
}