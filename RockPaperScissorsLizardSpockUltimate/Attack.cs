using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Attack
    {
        //Trivial
        public string name;

        //Wins against
        protected int againstRock;
        protected int againstPaper;
        protected int againstScissors;
        protected int againstLizard;
        protected int againstSpock;


        //Stats
        public double damage;
        protected double defense;
        protected double combo;
        protected double criticalHit;


        protected double theDamage;

        public int Against(int attackIndex)
        {
            if (attackIndex == 1)
            {
                return againstRock;
            }
            else if (attackIndex == 2)
            {
                return againstPaper;
            }
            else if (attackIndex == 3)
            {
                return againstScissors;
            }
            else if (attackIndex == 4)
            {
                return againstLizard;
            }
            else
            {
                return againstSpock;
            }
        }


        public double DoDamage ()
        {
            theDamage = damage / 20;
            return theDamage;
        }


        public double TakeDamage()
        {
                theDamage = defense / 20;
                return theDamage;
        }

    }
}
