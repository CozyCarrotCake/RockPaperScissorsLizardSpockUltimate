﻿using System;
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
            againstPaper = -1;
            againstScissors = 1;
            againstLizard = -1;
            againstSpock = 0;

            damage = 70;
            defense = 70;
            combo = 0.12;
            criticalHit = 0.2;
        }
    }
}