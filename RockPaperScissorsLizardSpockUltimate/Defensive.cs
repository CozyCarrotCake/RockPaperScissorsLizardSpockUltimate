using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Defensive : Character
    {

        public Defensive()
        {
            damage = 25;
            defense = 50;
            combo = 1.15;
            criticalHit = 15;

            behaviorAttack = new Block();
        }
    }
}
