using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheBreaker : Blocker
    {
        public TheBreaker()
        {
            name = "The Breaker";

            combo += 0.15;

            whenPassive = 3;
        }

        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Combo + 0.15");
            Console.WriteLine("Passive: Combobreaker - Breaks enemy combo if it gets a streak of 3");

        }

        public override void Passive(Character otherChar, Attack yourAttack, Attack otherAttack)
        {
            if (otherChar.Streak == 3)
            {
                Console.WriteLine("The Breaker broke " + otherChar.name + "'s combo!");
                otherChar.Streak = 0;
            }


        }

    }
}
