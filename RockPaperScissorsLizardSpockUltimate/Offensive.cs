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
            damage = 30;
            defense = 20;
            combo = 1.15;
            criticalHit = 15;

            behaviorAttack = new Snap();
        }
    }
}
