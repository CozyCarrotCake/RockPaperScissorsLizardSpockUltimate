using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraEdward : Scissors
    {
        public TraEdward()
        {
            name = "Edward";

            againstSpock += 1;
            againstPaper += 1;
            combo += 0.2;
        }
    }
}
