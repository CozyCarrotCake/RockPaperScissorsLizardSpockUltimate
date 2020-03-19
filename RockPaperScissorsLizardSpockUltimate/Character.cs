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
        public double hp = 100.0;

        protected double damage;
        protected double defense;
        protected double combo;
        protected double criticalHit;


        public double DoDamage()
        {
            double theDamage = damage / 10;

            return theDamage;
        }

        public double TakeDamage()
        {
            double theDamage = defense / 2;

            return theDamage;

            
        }


        public void LostHealth(double takenDamage)
        {
            hp -= takenDamage;

        }
    }
}
