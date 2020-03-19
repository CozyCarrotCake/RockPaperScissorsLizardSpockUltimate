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


        protected double theDamage;



        public double DoDamage()
        {
            theDamage = damage / 20;
            return theDamage;
        }


        public double TakeDamage()
        {
            theDamage = defense / 20;
            return theDamage;
        }


        public double LostHealth
        {
            get
            {
                return hp;
            }
            set
            {
                hp -= value;
            }
            

            

        }
    }
}
