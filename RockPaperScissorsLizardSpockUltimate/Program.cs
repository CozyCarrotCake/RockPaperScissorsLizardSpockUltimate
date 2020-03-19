using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Program

        
    {
        static void Main(string[] args)
        {
            Character yourChar = new Character();
            Character opponentChar = new Character();


            Intro();

            Fight(yourChar, opponentChar);
            
            
            Console.ReadLine();
        }



        static void Intro()
        {
            Console.WriteLine("Hello and welcome to TITLE");
            Console.WriteLine("Choose a character!");

            string charSelection = Console.ReadLine();
            int charIndex;
            bool charSuccess = int.TryParse(charSelection, out charIndex);

            while (charSuccess == false || charIndex < 1 || charIndex > 12)
            {
                Console.WriteLine("Please write the number of one of the characters!");
                charSelection = Console.ReadLine();
                charSuccess = int.TryParse(charSelection, out charIndex);

            }

            Console.WriteLine("Allright you chose CHARACTER");
            //Make 3 times

            Console.WriteLine("Your opponent iiiiis CHARACTER");

            Console.WriteLine("Time to fight!");

        }



        static void Fight(Character yourChar, Character opponentChar)
        {
            double damageDealt = 10;
            double damageTaken = 0;

            int attackIndex = 0;
            Attack yourAttack = new Attack();
            Attack opponentAttack = new Attack();

            bool didChoose;

            int wOL;
            

            while (yourChar.hp > 0 && opponentChar.hp > 0)
            {
                Console.WriteLine("Your remaining HP: " + yourChar.hp);
                Console.WriteLine("Your opponents remaining HP: " + opponentChar.hp);


                //Choose Attack

                Console.WriteLine("Choose your attack!");

                string attackSelection = Console.ReadLine();
                bool attackSuccess = int.TryParse(attackSelection, out attackIndex);

                if (attackSuccess == false || attackIndex < 1 || attackIndex > 5)
                {
                    Console.WriteLine("You failed to choose an attack!");

                    didChoose = false;
                }
                else
                {
                    didChoose = true;
                }

                yourAttack = YourAttack(attackIndex, yourAttack, didChoose);

                if (didChoose == true)
                {
                    //Make smart
                    Random opponentAttackGen = new Random();
                    attackIndex = opponentAttackGen.Next(1, 6);
                    opponentAttack = OpponentAttack(attackIndex);
                }
                
                
                Console.WriteLine("You chose " + yourAttack.name);
                Console.WriteLine("Your opponent chose " + opponentAttack.name);


                
                wOL = WinOrLoose(attackIndex, yourAttack);

                if (wOL == 1)
                {
                    Console.WriteLine("You Win!");
                    damageDealt = damageDealt + ((yourAttack.DoDamage() + yourChar.DoDamage()) / 2 );

                    //combo

                    damageTaken = damageDealt - ((opponentAttack.TakeDamage() + opponentChar.TakeDamage()) / 2 );

                    if (damageTaken < 5)
                    {
                        damageTaken = 5;
                    }

                    opponentChar.LostHealth(damageTaken);
                    
                }
                else if (wOL == 0)
                {
                    Console.WriteLine("It's a Draw!");
                }
                else
                {
                    Console.WriteLine("You Loose!");

                    damageDealt = damageDealt + ((opponentAttack.DoDamage() + opponentChar.DoDamage()) / 2);

                    //combo

                    damageTaken = damageDealt - ((yourAttack.TakeDamage() + yourChar.TakeDamage()) / 2);

                    if (damageTaken < 5)
                    {
                        damageTaken = 5;
                    }


                    yourChar.LostHealth(damageTaken);
                }

            }
            


        }




        static int ChooseAttack(int attackIndex, Attack yourAttack)
        {
            


            return attackIndex;
        }


        static Attack FailedAttack()
        {
            Attack yourAttack = new None();

            return yourAttack;
        }

        static Attack YourAttack(int attackIndex, Attack yourAttack, bool hey)
        {
            if (hey == true)
            {                
                yourAttack = WhichAttack(attackIndex);
            }
            else
            {
                yourAttack = new None();
            }

            return yourAttack;
        }

        static Attack OpponentAttack(int attackIndex)
        {
            Attack opponentAttack = WhichAttack(attackIndex);

            return opponentAttack;
        }




        static Attack WhichAttack(int attackIndex)
        {
            Attack whichYourAttack = new Attack();

            if (attackIndex == 1)
            {
                whichYourAttack = new Rock();
            }
            else if (attackIndex == 2)
            {
                whichYourAttack = new Paper();
            }
            else if (attackIndex == 3)
            {
                whichYourAttack = new Scissors();
            }
            else if (attackIndex == 4)
            {
                whichYourAttack = new Lizard();
            }
            else
            {
                whichYourAttack = new Spock();
            }

            return whichYourAttack;

        }



        static int WinOrLoose(int attackIndex, Attack yourAttack)
        {
            int wOL = yourAttack.Against(attackIndex);

            return wOL;
        }

    }
}
