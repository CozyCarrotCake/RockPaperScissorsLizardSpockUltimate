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
            damage = 50;
            defense = 25;
            combo = 1.15;
            criticalHit = 15;

            behaviorAttack = new Snap();
        }
    }
}
