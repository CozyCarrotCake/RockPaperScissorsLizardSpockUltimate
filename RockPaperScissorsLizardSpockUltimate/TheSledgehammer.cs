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

            whenPassive = 1;
        }

        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Damage + 20%" );
            Console.WriteLine("Passive: Thick Skin - Can't be critical hit");

        }

        public override void Passive(Character otherChar, Attack yourAttack, Attack otherAttack)
        {

            Console.WriteLine("It's a crit, but the crit doesn't affect the Sledgehammer!");


        }
    }
}
