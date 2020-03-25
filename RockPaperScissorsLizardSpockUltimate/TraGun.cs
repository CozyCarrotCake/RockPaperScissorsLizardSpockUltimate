using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraGun : Spock
    {
        public TraGun()
        {
            name = "Gun";

            againstLizard += 1;
            againstScissors += 1;
            damage += 20;
        }
    }
}
