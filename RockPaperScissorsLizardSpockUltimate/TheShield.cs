using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheShield : Blocker
    {
        public TheShield()
        {
            name = "The Shield";

            defense *= 1.2;
        }

        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Defense + 20%");

        }
    }
}
