using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraKhaaan : Spock
    {
        public TraKhaaan()
        { 
            name = "Khaaan";

            againstSpock += 1;
            againstPaper += 1;
            criticalHit += 20;
        }
    }
}
