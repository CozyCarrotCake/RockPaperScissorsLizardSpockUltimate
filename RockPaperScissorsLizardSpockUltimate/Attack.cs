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
        public double combo { get; protected set; }
        public int criticalHit { get; protected set; }


        //Transformations
        public Attack firstTransform { get; protected set; }
        public Attack secondTransform { get; protected set; }


        //Method Thingy
        protected double theDamage;







        //METHODS

        // Check Wins
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


        //Damage Methods

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


        //Transform

        public void Transformations(int specials) 
        {
            if (specials > 0)
            {
                Console.WriteLine("2. " + firstTransform.name);
                Console.WriteLine("3. " + secondTransform.name);
            }
            else
            {
                Console.WriteLine("You've used your 2 specials for this fighter!");
            }
            
        }


        public virtual void Transform()
        {
            //Gets overrode in the subclasses, but needs to be able to get called from program so gets created here.
        }
        



        //Info

        public void Info()
        {
            Console.WriteLine("Good Against: ");
            if (againstRock == 1)
            {
                Console.WriteLine("Rock");
            }
            if (againstPaper == 1)
            {
                Console.WriteLine("Paper");
            }
            if (againstScissors == 1)
            {
                Console.WriteLine("Scissors");
            }
            if (againstLizard == 1)
            {
                Console.WriteLine("Lizard");
            }
            if (againstSpock == 1)
            {
                Console.WriteLine("Spock");
            }


            //Transformations
        }



    }
}
