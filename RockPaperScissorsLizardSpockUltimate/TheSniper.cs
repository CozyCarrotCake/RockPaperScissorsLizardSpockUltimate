using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheSniper : Assassin
    {
        public TheSniper()
        {
            name = "The Sniper";


            criticalHit += 15;
        }


        public override void Info(int Index)
        {
            base.Info(Index);
            
            Console.WriteLine("Critical Hit + " + 15);

        }
    }
}
