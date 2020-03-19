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

            ChooseCharacter(yourChar);

            RandomCharacter(opponentChar);


            Fight(yourChar, opponentChar);
            
            
            Console.ReadLine();
        }



        static void Intro()
        {
            Console.WriteLine("Hello and welcome to TITLE");

        }


        static Character ChooseCharacter(Character yourChar)
        {

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

            if (charIndex < 7)
            {
                yourChar = new Offensive();
            }
            else
            {
                yourChar = new Defensive();
            }

            Console.WriteLine("Allright you chose CHARACTER");
            //Make 3 times

            return yourChar;
        }


        static Character RandomCharacter(Character opponentChar)
        {



            Console.WriteLine("Your opponent iiiiis CHARACTER");

            Console.WriteLine("Time to fight!");

            return opponentChar;
        }




        static void Fight(Character yourChar, Character opponentChar)
        {
            double damageDealt = 10;

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

                    DealDamage(damageDealt, yourAttack, opponentAttack, yourChar, opponentChar);
                }
                else if (wOL == 0)
                {
                    Console.WriteLine("It's a Draw!");
                }
                else
                {
                    Console.WriteLine("You Loose!");

                    TakeDamage(damageDealt, yourAttack, opponentAttack, yourChar, opponentChar);

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





        static void DealDamage(double damageDealt, Attack yourAttack, Attack opponentAttack, Character yourChar, Character opponentChar)
        {

            damageDealt = damageDealt + yourAttack.DoDamage() + yourChar.DoDamage();
            //combo

            damageDealt = damageDealt - opponentAttack.TakeDamage() + opponentChar.TakeDamage();

            if (damageDealt < 5)
            {
                damageDealt = 5;
            }

            opponentChar.LostHealth = damageDealt;


        }

        static void TakeDamage(double damageDealt, Attack yourAttack, Attack opponentAttack, Character yourChar, Character opponentChar)
        {
            damageDealt = damageDealt + opponentAttack.DoDamage() + opponentChar.DoDamage();
            
            //combo

            damageDealt = damageDealt - yourAttack.TakeDamage() + yourChar.TakeDamage();

            if (damageDealt < 5)
            {
                damageDealt = 5;
            }


            yourChar.LostHealth = damageDealt;
        }


    }
}
