using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheSniper : Assassin
    {
        int pasSniper = 0;

        public TheSniper()
        {
            name = "The Sniper";


            criticalHit += 15;

            whenPassive = 3;
        }


        public override void Info(int Index)
        {
            base.Info(Index);
            
            Console.WriteLine("Critical Hit + 15%");
            Console.WriteLine("Passive: Bullseye - Critical Hit chance builds up with combo");

        }

        public override void Passive(Character otherChar, Attack yourAttack, Attack otherAttack)
        {
            if (streak > 0)
            {
               
                criticalHit += 2;
                pasSniper += 2;
                
            }
            else
            {
                criticalHit -= pasSniper;
                pasSniper = 0;
            }

        }
    }
}
