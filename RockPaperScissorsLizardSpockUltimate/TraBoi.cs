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

            againstLizard += 1;
            againstSpock += 1;
            criticalHit += 20;
        }
    }
}
