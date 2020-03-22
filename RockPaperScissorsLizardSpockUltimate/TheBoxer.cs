using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheBoxer : Bruiser
    {
        public TheBoxer()
        {
            name = "The Boxer";
            
            combo += 0.15;
        }

        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Combo + 0.15");

        }

    }
}
