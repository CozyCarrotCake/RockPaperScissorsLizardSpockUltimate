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
        protected double hp = 100.0;

        protected double damage;
        protected double defense;
        public double combo { get; protected set; }
        public int criticalHit { get; protected set; }


        //Får ett värde i offense / defensive klasserna
        public Attack behaviorAttack { get; protected set; }

        //Specifierar när karaktärens passive ska köras
        public int whenPassive { get; protected set; }


        // Thingys
        protected double theDamage;
               
        protected int streak = 0;

        public int specials { get; protected set; } = 2;

        protected int against;

        public bool wonRound;




        //METHODS

        public virtual void Info(int index)
        {
            //Visar info beroende på vilken karaktär spelaren valt
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
         
        //tar din hp - det damaga-värde som själva fight-metoden räknat ut för rundan
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

        
        //Heal HP
        public double HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }



        //Håller against infon för whoWon metoden i singleplayer
        public int Against
        {
            get
            {
                return against;
            }
            set
            {
                against = value;
            }
        }

               

        //Combo Streak, vinner man en runda adderas ett på streaken, förlorar man dras den ner till 0
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
        public void BehaviorSpecial(bool behaviorSpecial)
        {
            if (behaviorSpecial == true)
            {
                Console.WriteLine("1. " + behaviorAttack.name);
            }
            else
            {
                Console.WriteLine("You have used your Behavior attack for this fight!");
            }
        }


        //How Many transformations can this character do, everyone has 2
        public int Specials
        {
            get
            {
                return specials;
            }
            set
            {
                if (specials > 0)
                {
                    specials-= value;
                }
                
            }
            
        }


        //Passives, körs i subklassen, kallas här
        public virtual void Passive(Character otherChar, Attack yourAttack, Attack otherAttack)
        {
            //0: Quick

            //1: Sledge

            //2: Invis

            //3: Cat, Boxer, Breaker, Shield, Sniper


        }



        
    
    }
}
