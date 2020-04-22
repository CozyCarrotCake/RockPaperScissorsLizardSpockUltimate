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


        //Transformationthingys
        protected bool transRock;
        protected bool transPaper;
        protected bool transScissors;
        protected bool transLizard;
        protected bool transSpock;

        protected bool transDmg;
        protected bool transDef;
        protected bool transCombo;
        protected bool transCrit;



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
        //writes out the transformations
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
        
        //när man transformerar sätter den 3 boolvärden till true, dessa körs sedan här för att göra attackens stats bättre.
        protected void TransformStats()
        {
            if (transRock == true)
            {
                againstRock += 1;
            }
            else if (transPaper == true)
            {
                againstPaper += 1;
            }
            else if (transScissors == true)
            {
                againstScissors += 1;
            }
            else if (transLizard == true)
            {
                againstLizard += 1;
                
            }
            else if (transSpock == true)
            {
                againstSpock += 1;
            }
            else if (transDmg == true)
            {
                damage += 20;
            }
            else if (transDef == true)
            {
                defense += 20;
            }
            else if (transCombo == true)
            {
                combo += 0.2;
            }
            else if (transCrit == true)
            {
                criticalHit += 20;
            }

            
        } 



        //Info om attackerna

        public void Info()
        {
            Console.WriteLine("Good Against: ");
            if (againstRock == 1)
            {
                Console.WriteLine(" - Rock");
            }
            if (againstPaper == 1)
            {
                Console.WriteLine(" - Paper");
            }
            if (againstScissors == 1)
            {
                Console.WriteLine(" - Scissors");
            }
            if (againstLizard == 1)
            {
                Console.WriteLine(" - Lizard");
            }
            if (againstSpock == 1)
            {
                Console.WriteLine(" - Spock");
            }


            Console.WriteLine("Stats: ");
            Console.WriteLine(" - Damage: " + damage);
            Console.WriteLine(" - Defense: " + defense);
            Console.WriteLine(" - Combo Multiplyer: " + combo);
            Console.WriteLine(" - Critical Hit: " + criticalHit);
        }

        public void TransformationInfo()
        {
            //First Transform

            Console.WriteLine("1. " + firstTransform.name);
            Console.WriteLine("Bonus Winnability Against: ");

            if (firstTransform.transRock == true)
            {
                Console.WriteLine(" - Rock");
            }
            if (firstTransform.transPaper == true)
            {
                Console.WriteLine(" - Paper");
            }
            if (firstTransform.transScissors == true)
            {
                Console.WriteLine(" - Scissors");
            }
            if (firstTransform.transLizard == true)
            {
                Console.WriteLine(" - Lizard");
            }
            if (firstTransform.transSpock == true)
            {
                Console.WriteLine(" - Spock");
            }

            Console.WriteLine("Bonus Stats: ");
            if (firstTransform.transDmg == true)
            {
                Console.WriteLine(" - Damage: +20");
            }
            if (firstTransform.transDef == true)
            {
                Console.WriteLine(" - Defense: +20");
            }
            if (firstTransform.transCombo == true)
            {
                Console.WriteLine(" - Combo Bonus: +0.20");
            }
            if (firstTransform.transCrit == true)
            {
                Console.WriteLine(" - Cirtical Hit: +20");
            }


            //Second Transform

            Console.WriteLine();
            Console.WriteLine("2. " + secondTransform.name);

            Console.WriteLine("Bonus winnability against: ");

            if (secondTransform.transRock == true)
            {
                Console.WriteLine(" - Rock");
            }
            if (secondTransform.transPaper == true)
            {
                Console.WriteLine(" - Paper");
            }
            if (secondTransform.transScissors == true)
            {
                Console.WriteLine(" - Scissors");
            }
            if (secondTransform.transLizard == true)
            {
                Console.WriteLine(" - Lizard");
            }
            if (secondTransform.transSpock == true)
            {
                Console.WriteLine(" - Spock");
            }

            Console.WriteLine("Bonus Stats: ");
            if (secondTransform.transDmg == true)
            {
                Console.WriteLine(" - Damage: +20");
            }
            if (secondTransform.transDef == true)
            {
                Console.WriteLine(" - Defense: +20");
            }
            if (secondTransform.transCombo == true)
            {
                Console.WriteLine(" - Combo Bonus: +0.20");
            }
            if (secondTransform.transCrit == true)
            {
                Console.WriteLine(" - Cirtical Hit: +20");
            }
        }

        public void BehavioralInfo()
        {
            if (name == "Snap")
            {
                Console.WriteLine("The Offensive fighters' Behavioral Transformation");
                Console.WriteLine("Beats every other Attack, except the Block");
                Console.WriteLine();
                Console.WriteLine("Stats: ");
                Console.WriteLine(" - Damage: " + damage);
                Console.WriteLine(" - Defense: " + defense);
                Console.WriteLine(" - Combo Multiplyer: " + combo);
                Console.WriteLine(" - Critical Hit: " + criticalHit);
            }
            else if(name == "Block")
            {
                Console.WriteLine("The Defensive fighters' Behavioral Transformation");
                Console.WriteLine("Draws with every other Attack, even the Block, as well as denying every Passive");
            }
        }

    }
}
