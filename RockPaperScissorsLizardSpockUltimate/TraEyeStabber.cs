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

            transSpock = true;
            transLizard = true;
            transCrit = true;

        }
    }
}
