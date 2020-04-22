using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraTree : Paper
    {
        public TraTree()
        {
            name = "Tree";

            transScissors = true;
            transRock = true;
            transDef = true;

            TransformStats();
        }
    }
}
