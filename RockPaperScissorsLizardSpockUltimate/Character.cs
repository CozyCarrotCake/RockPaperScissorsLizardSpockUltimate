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
        public double combo { get; protected set; }
        public int criticalHit { get; protected set; }

        public Attack behaviorAttack { get; protected set; }


        // Thingys
        protected double theDamage;
               
        protected int streak = 0;



        //METHODS

        public virtual void Info(int index)
        {
            
            if (index < 4)
            {
                Console.Write("Offensive | ");
                if (index < 2)
                {
                    Console.WriteLine("Bruiser");
                }
                else
                {
                    Console.WriteLine("Assassin");
                }
            }
            else
            {
                Console.Write("Defensive | ");
                if (index < 6)
                {
                    Console.WriteLine("Blocker");
                }
                else
                {
                    Console.WriteLine("Evader");
                }
            }
        }




        //Damage Methods
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



        //Combo Streak
        public int Streak
        {
            get
            {
                return streak;
            }
            set
            {
                if (value != 0)
                {
                    streak += value;
                }
                else
                {
                    streak = value;
                }
                
            }
        }



        //Special
        public void BehaviorSpecial()
        {
            Console.WriteLine("1. " + behaviorAttack.name);
        }


        //Passives
        public virtual void Passive()
        {

        }


    }
}
