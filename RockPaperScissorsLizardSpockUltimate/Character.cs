using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Character
    {
        //Trivial
        public string name;

        //Stats
        public float hp = 100.0f;

        protected int damage;
        protected int defense;
        protected double combo;
        protected double criticalHit;


        public double DoDamage()
        {
            double theDamage = damage;

            return theDamage;
        }

        public double TakeDamage(double takenDamage)
        {
            takenDamage = takenDamage / defense;

            return takenDamage;
        }

    }
}
