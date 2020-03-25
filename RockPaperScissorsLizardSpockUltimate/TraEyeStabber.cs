using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraEyeStabber : Scissors
    {
        public TraEyeStabber()
        {
            name = "Eye Stabber";

            againstSpock += 1;
            againstLizard += 1;
            criticalHit += 20;
        }
    }
}
