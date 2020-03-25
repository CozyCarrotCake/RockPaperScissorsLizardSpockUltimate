using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraHardRock : Rock
    {
        public TraHardRock()
        {
            name = "Hard Rock";

            againstSpock += 1;
            againstLizard += 1;
            combo += 0.2;
        }

    }
}
