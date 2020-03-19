using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Offensive : Character
    {

        public Offensive()
        {
            name = "";
            
            damage = 50;
            defense = 25;
            combo = 1.25;
            criticalHit = 30;
        }
    }
}
