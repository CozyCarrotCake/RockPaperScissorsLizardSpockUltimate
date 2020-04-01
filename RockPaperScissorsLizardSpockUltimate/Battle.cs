using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Battle
    {
        
        //INSTANCES

        //the characters, gets new subclasses if your current fighter dies and you have someone alive
        Character yourChar = new Character();
        Character opponentChar = new Character();

        //The attacks, gets new subclasses each round based on what is picked and maybe transformed
        Attack yourAttack = new Attack();
        Attack opponentAttack = new Attack();




        //ATTACKS

        //If the player chose an attack or not
        bool didChoose;

        //Are used to define which attack is chosen or randomized
        int attackIndex = 0;
        int oppAttackIndex = 0;

        //Can do the behavior special, only once per game so is created here
        bool canDoBehavior = true;
        bool opponentCanDoBehavior = true;

        //The varible that the damage is built upon, base is 10
        double damageDealt = 10;





        //GENERAL BOOLS

        //If you won the round
        bool didWin;

        //if the entire fight is done or not
        bool done = false;

        



        //The fight, runs the fight
        public bool Fight(List<Character> yourCharacters, List<Character> opponentCharacters)
        {
            
            yourChar = yourCharacters[0];
            yourCharacters.Remove(yourChar);
            opponentChar = opponentCharacters[0];
            opponentCharacters.Remove(opponentChar);
            Console.WriteLine("First off, " + yourChar.name + " vs. " + opponentChar.name);


            while (done == false)
            {

                //Remaining HP
                Console.WriteLine("Your remaining HP: " + yourChar.HP);
                Console.WriteLine("Your opponents remaining HP: " + opponentChar.HP);



                //Pick your Attack
                yourAttack = ChooseAttack();

                
                //Only plays if you picked an attack
                if (didChoose == true)
                {

                    //Opponents Attack
                    //Make smart
                    opponentAttack = RandomAttack();


                    Console.Clear();

                    // Attack UI
                    Console.WriteLine("");
                    Console.WriteLine("You chose " + yourAttack.name);
                    Console.WriteLine("Your opponent chose " + opponentAttack.name);

                    

                    //TRANSFORMATION
                    yourAttack = YourTransformation();

                    

                    // Enemy transformation
                    opponentAttack = EnemyTransformation();
                    
                }

                               

                // Which attack wins
                WinOrLoose(yourChar, yourAttack, oppAttackIndex);
                WinOrLoose(opponentChar, opponentAttack, attackIndex);



                //Keep on fixing passive!!!!!!!!!!!!!!!!!!!!!!!
                yourChar.Passive(opponentChar);


                Console.ReadLine();



                // Who wins and does the damage
                WhoWins();





                //If your fighter dies
                int deathQue = 0;
                DidDie(yourCharacters, yourChar, deathQue);

                //If opponent fighter dies
                deathQue = 1;
                DidDie(opponentCharacters, opponentChar, deathQue);

                

                Console.Clear();

            }

            return didWin;

        }





        //Choose Your Attack
        public Attack ChooseAttack()
        {

            Console.WriteLine("Choose your attack!");
            Console.WriteLine("1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors");
            Console.WriteLine("4. Lizard");
            Console.WriteLine("5. Spock");

            /* TIMER

            Timer timer1 = new Timer(1000);
            timer1.Elapsed += Timer_Elapsed;
            timer1.Start();
            */



            string attackSelection = Console.ReadLine();
            bool attackSuccess = int.TryParse(attackSelection, out attackIndex);

            if (attackSuccess == false || attackIndex < 1 || attackIndex > 5)
            {
                Console.WriteLine("You failed to choose an attack!");

                didChoose = false;
                //timer1.Stop();
            }
            else
            {
                didChoose = true;
                //timer1.Stop();
            }

            yourAttack = YourAttack();
            return yourAttack;
        }

        //Did choose Attack
        public Attack YourAttack()
        {
            if (didChoose == true)
            {
                yourAttack = WhichAttack(attackIndex);
            }
            else
            {
                yourAttack = new None();
            }

            return yourAttack;
        }


        //Randomized Attack
        public Attack RandomAttack()
        {
            Random opponentAttackGen = new Random();
            oppAttackIndex = opponentAttackGen.Next(1, 6);
            opponentAttack = OpponentAttack();
            return opponentAttack;
        }

        public Attack OpponentAttack()
        {
            Attack opponentAttack = WhichAttack(oppAttackIndex);

            return opponentAttack;
        }


        //Which Attack was chosen 
        public Attack WhichAttack(int index)
        {
            Attack whichYourAttack = new Attack();

            if (index == 1)
            {
                whichYourAttack = new Rock();
            }
            else if (index == 2)
            {
                whichYourAttack = new Paper();
            }
            else if (index == 3)
            {
                whichYourAttack = new Scissors();
            }
            else if (index == 4)
            {
                whichYourAttack = new Lizard();
            }
            else
            {
                whichYourAttack = new Spock();
            }

            return whichYourAttack;

        }


       




        //Transformations!!!
        public Attack YourTransformation()
        {
            Console.WriteLine("");
            Console.WriteLine("Do you wanna transform your attack?");

            //Writes out and creates the attacks in the Classes



            yourChar.BehaviorSpecial(canDoBehavior);
            yourAttack.Transform();
            yourAttack.Transformations(yourChar.specials);



            //Choose transformation

            string transform = Console.ReadLine();
            int transformIndex;
            bool transformSuccess = int.TryParse(transform, out transformIndex);

            if (transformSuccess == false || transformIndex > 3 || transformIndex < 1)
            {
                Console.WriteLine("You chose not to transform!");
            }
            else if (transformIndex == 1)
            {
                if (canDoBehavior == true)
                {
                    Console.WriteLine("You chose to transform your " + yourAttack.name + " into a " + yourChar.behaviorAttack.name);
                    yourAttack = yourChar.behaviorAttack;
                    canDoBehavior = false;
                }
                else
                {
                    Console.WriteLine("You have already used your Behavior transformation for this game!");
                }
            }
            else if (yourChar.specials > 0)
            {
                if (transformIndex == 2)
                {
                    Console.WriteLine("You chose to transform your " + yourAttack.name + " into a " + yourAttack.firstTransform.name);
                    yourAttack = yourAttack.firstTransform;
                    yourChar.Specials = 1;
                }
                else if (transformIndex == 3)
                {
                    Console.WriteLine("You chose to transform your " + yourAttack.name + " into a " + yourAttack.secondTransform.name);
                    yourAttack = yourAttack.secondTransform;
                    yourChar.Specials = 1;
                }
            }
            else if (yourChar.specials == 0 && (transformIndex == 2 || transformIndex == 3))
            {
                Console.WriteLine("You have already used this fighter's 2 transformations!");
            }
            

            return yourAttack;

        }
        
        public Attack EnemyTransformation()
        {
            Random transformGen = new Random();
            int transformInt = transformGen.Next(100);
            if (transformInt < 10)
            {
                if (opponentChar.Specials > 0 && opponentCanDoBehavior == true)
                {
                    transformInt = transformGen.Next(0, 3);
                }
                else if (opponentChar.Specials == 0)
                {
                    transformInt = 0;
                }
                else if (opponentCanDoBehavior == false)
                {
                    transformInt = transformGen.Next(1, 3);
                }


                opponentAttack.Transform();


                if (transformInt == 0)
                {
                    Console.WriteLine("Your enemy chose to transform their " + opponentAttack.name + " into a " + opponentChar.behaviorAttack.name);
                    opponentAttack = opponentChar.behaviorAttack;
                }
                else if (transformInt == 1)
                {
                    Console.WriteLine("Your opponent chose to transform their " + opponentAttack.name + " into a " + opponentAttack.firstTransform.name);
                    opponentAttack = opponentAttack.firstTransform;
                }
                else
                {
                    Console.WriteLine("Your opponent chose to transform their " + opponentAttack.name + " into a " + opponentAttack.secondTransform.name);
                    opponentAttack = opponentAttack.secondTransform;
                }
            }
            else
            {
                Console.WriteLine("Your opponent chose not to transform!");
            }

            return opponentAttack;
        }




        //Check For Winner
        public void WinOrLoose(Character chara, Attack attack, int index)
        {
            chara.Against = attack.Against(index);
            
        }

        public void WhoWins()
        {
            Console.WriteLine(yourChar.Against);
            Console.WriteLine(opponentChar.Against);
            
            if (yourChar.Against > opponentChar.Against)
            {
                Console.WriteLine("You Win!");

                DealDamage();
            }
            else if (yourChar.Against < opponentChar.Against)
            {
                Console.WriteLine("You Loose!");

                TakeDamage();

            }
            else
            {
                Console.WriteLine("It's a Draw!");
            }

            Console.ReadLine();
        }





        //Calculating Damage
        public void DealDamage()
        {
            //main damage
            damageDealt += yourAttack.DoDamage() + yourChar.DoDamage();


            //combo            
            opponentChar.Streak = 0;
            yourChar.Streak = 1;
            double comboValue = Math.Pow((yourAttack.combo * yourChar.combo), yourChar.Streak);
            Console.WriteLine(comboValue);
            damageDealt *= comboValue;


            //crits
            Random critGen = new Random();
            int hit = critGen.Next(100);

            if (hit <= (yourAttack.criticalHit + yourChar.criticalHit) / 2)
            {
                Console.WriteLine("It's a crit!");
                damageDealt *= 2;
            }




            damageDealt = damageDealt - opponentAttack.TakeDamage() + opponentChar.TakeDamage();

            if (damageDealt < 5)
            {
                damageDealt = 5;
            }

            opponentChar.LostHealth = damageDealt;


        }

        public void TakeDamage()
        {
            // main damage
            damageDealt = damageDealt + opponentAttack.DoDamage() + opponentChar.DoDamage();

            //combo
            yourChar.Streak = 0;
            opponentChar.Streak = 1;
            double comboValue = Math.Pow((opponentAttack.combo * opponentChar.combo), opponentChar.Streak);
            Console.WriteLine(comboValue);
            damageDealt *= comboValue;


            //crit
            Random critGen = new Random();
            int hit = critGen.Next(100);

            if (hit <= (opponentAttack.criticalHit + opponentChar.criticalHit) / 2)
            {
                Console.WriteLine("It's a crit!");
                damageDealt *= 2;
            }




            //taken
            damageDealt = damageDealt - yourAttack.TakeDamage() + yourChar.TakeDamage();

            if (damageDealt < 5)
            {
                damageDealt = 5;
            }


            yourChar.LostHealth = damageDealt;
        }





        //Checks if the fighters die, takes parameters because it runs on both the player and opponent
        public void DidDie(List<Character> characters, Character chara, int deathQue)
        {
            if (chara.HP < 0)
            {
                Console.Clear();
                Console.WriteLine(chara.name + " can no longer fight!");

                if (characters.Count != 0)
                {
                                        
                    chara = characters[0];
                    characters.Remove(chara);
                    Console.WriteLine(chara.name + " jumps in!");
                    chara.HP = 100;

                }
                else
                {
                    if (deathQue == 0)
                    {
                        Console.WriteLine("All your fighters are unable to continue!");
                        didWin = false;
                    }
                    if (deathQue == 1)
                    {
                        Console.WriteLine("All your opponent's fighters are unable to continue!");
                        didWin = true;
                    }

                    done = true;
                }

                Console.ReadLine();
            }
        }


    }
}
