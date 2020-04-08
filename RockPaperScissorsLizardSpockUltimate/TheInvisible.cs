using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheInvisible : Evader
    {
        public TheInvisible()
        {
            name = "The Invisible";


            criticalHit += 15;

            whenPassive = 2;
        }


        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Crit + 0.15");
            Console.WriteLine("Passive: Uh, Invisible? - Has a small chance of avoiding taken damage from a losing hand.");

        }

        public override void Passive(Character otherChar, Attack yourAttack, Attack otherAttack, bool wonRound)
        {
            
            Console.WriteLine(otherChar.name + " missed the attack on the Invisible!");



        }

    }
}
