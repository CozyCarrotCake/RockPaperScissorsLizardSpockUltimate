using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Program




        //ITS ALWAYS A DRAW?
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
            double damageDealt = 0;
            double damageTaken = 0;

            int attackIndex = 0;
            Attack yourAttack = new Attack();
            Attack opponentAttack = new Attack();

            int wOL;
            

            while (yourChar.hp > 0 && opponentChar.hp > 0)
            {
                Console.WriteLine(yourChar.hp);
                Console.WriteLine(opponentChar.hp);


                //Choose Attack

                Console.WriteLine("Choose your attack!");

                string attackSelection = Console.ReadLine();
                bool attackSuccess = int.TryParse(attackSelection, out attackIndex);

                if (attackSuccess == false || attackIndex < 1 || attackIndex > 5)
                {
                    Console.WriteLine("You failed to choose an attack!");

                    FailedAttack();

                }
                else
                {
                    yourAttack = YourAttack(attackIndex);
                    opponentAttack = OpponentAttack(attackIndex);
                }


                

                Console.WriteLine("You chose " + yourAttack.name);
                Console.WriteLine("Your opponent chose " + opponentAttack.name);




                wOL = WinOrLoose(attackIndex, yourAttack);

                if (wOL == 1)
                {
                    Console.WriteLine("You Win!");
                    damageDealt = yourAttack.DoDamage() + yourChar.DoDamage();


                    damageTaken = opponentAttack.TakeDamage(damageDealt) + opponentChar.TakeDamage(damageDealt);


                    
                }
                else if (wOL == 0)
                {
                    Console.WriteLine("It's a Draw!");
                }
                else
                {
                    Console.WriteLine("You Loose!");
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

        static Attack YourAttack(int attackIndex)
        {
            Attack yourAttack = WhichAttack(attackIndex);

            return yourAttack;
        }

        static Attack OpponentAttack(int attackIndex)
        {
            Random opponentAttackGen = new Random();
            attackIndex = opponentAttackGen.Next(1, 6);
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
