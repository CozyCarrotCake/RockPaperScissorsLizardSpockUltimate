using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraBoi : Paper
    {
        public TraBoi()
        {
            name = "Boi";

            transLizard = true;
            transSpock = true;
            transCrit = true;

            TransformStats();
        }
    }
}
