﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraBoulder : Rock
    {
        public TraBoulder()
        {
            name = "Boulder";

            againstPaper += 1;
            againstRock += 1;
            damage += 20;
        }


    }
}
