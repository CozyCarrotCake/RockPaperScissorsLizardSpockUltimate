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

            transSpock = true;
            transLizard = true;
            transCombo = true;

            TransformStats();
        }

    }
}
