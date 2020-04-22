using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraDragon : Lizard
    {
        public TraDragon()
        {
            name = "Dragon";

            transSpock = true;
            transScissors = true;
            transDmg = true;
        }
    }
}
