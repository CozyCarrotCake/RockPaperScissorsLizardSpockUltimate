﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheSledgehammer : Bruiser
    {
        public TheSledgehammer()
        {
            name = "The Sledgehammer";

            damage *= 1.2;
        }

        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Damage + 20%" );

        }
    }
}