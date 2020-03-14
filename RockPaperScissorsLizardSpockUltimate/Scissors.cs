﻿using System;
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

            againstRock = -1;
            againstPaper = 1;
            againstScissors = 0;
            againstLizard = 1;
            againstSpock = -1;

            
            damage = 70;
            defense = 30;
            combo = 0.17;
            criticalHit = 0.25;
        }



    }
}