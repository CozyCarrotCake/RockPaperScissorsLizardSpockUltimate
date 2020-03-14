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
            float yourHP = 100.0f;
            float opponentHP = 100.0f;


            Intro();

            while (yourHP > 0 && opponentHP > 0)
            {
                Fight();
            }

            
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



        static void Fight()
        {
            Console.WriteLine("Choose your attack!");

            string attackSelection = Console.ReadLine();
            int attackIndex;
            bool attackSuccess = int.TryParse(attackSelection, out attackIndex);

            if (attackSuccess == false || attackIndex < 1 || attackIndex > 5)
            {
                Console.WriteLine("You failed to choose an attack!");
            }
            else
            {
                Attack yourAttack = WhichAttack(attackIndex);


                Random opponentAttackGen = new Random();
                attackIndex = opponentAttackGen.Next(1, 6);
                Attack opponentAttack = WhichAttack(attackIndex);

                Console.WriteLine("You chose " + yourAttack.name);
                Console.WriteLine("Your opponent chose " + opponentAttack.name);

                string h = "against" + opponentAttack.name;

                WinOrLoose(attackIndex, yourAttack);

            }
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



        static void WinOrLoose(int attackIndex, Attack yourAttack)
        {
            int wOL = yourAttack.Against(attackIndex);
            
            if (wOL == 1)
            {
                Console.WriteLine("You Win!");
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
}
