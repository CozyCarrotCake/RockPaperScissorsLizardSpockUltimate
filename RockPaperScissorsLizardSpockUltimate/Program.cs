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

            List<Character> characters = new List<Character>();

            characters.Add(new TheBoxer());
            characters.Add(new TheSledgehammer());
            characters.Add(new TheSniper());
            characters.Add(new TheCat());
            characters.Add(new TheShield());
            characters.Add(new TheBreaker());
            characters.Add(new TheQuick());
            //characters.Add(new TheSledgehammer());


            Intro();

            yourChar = ChooseCharacter(yourChar, characters);

            opponentChar = RandomCharacter(opponentChar, characters);

            Fight(yourChar, opponentChar);
            
            
            Console.ReadLine();
        }



        static void Intro()
        {
            Console.WriteLine("Hello and welcome to TITLE");

        }



        //Choosing CHaracters
        static Character ChooseCharacter(Character yourChar, List<Character> characters)
        {
            

            Console.WriteLine("Choose your character! Press the number of the character you want and enter!");

            for (int i = 0; i < 7; i++)
            {
                characters[i].Info(i);

            }

            string charSelection = Console.ReadLine();
            int charIndex;
            bool charSuccess = int.TryParse(charSelection, out charIndex);

            while (charSuccess == false || charIndex < 1 || charIndex > 8)
            {
                Console.WriteLine("Please write the number of one of the characters!");
                charSelection = Console.ReadLine();
                charSuccess = int.TryParse(charSelection, out charIndex);

            }

            Console.Clear();

            yourChar = characters[charIndex - 1];

            Console.WriteLine("Allright you chose " + yourChar.name);
            //Make 3 times

            return yourChar;
        }


        static Character RandomCharacter(Character opponentChar, List<Character> characters)
        {

            Random charGen = new Random();

            int charIndex = charGen.Next(1, 9);

            opponentChar = characters[charIndex - 1];

            Console.WriteLine("Your opponent iiiiis " + opponentChar.name);

            Console.WriteLine("Time to fight!");

            return opponentChar;
        }




        // The Battle
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




        //Choosing Attacks
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



        //Check For Winner

        static int WinOrLoose(int attackIndex, Attack yourAttack)
        {
            int wOL = yourAttack.Against(attackIndex);

            return wOL;
        }



        //Calculating Damage

        static void DealDamage(double damageDealt, Attack yourAttack, Attack opponentAttack, Character yourChar, Character opponentChar)
        {
            //main damage
            damageDealt += yourAttack.DoDamage() + yourChar.DoDamage();


            //combo
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

        static void TakeDamage(double damageDealt, Attack yourAttack, Attack opponentAttack, Character yourChar, Character opponentChar)
        {
            // main damage
            damageDealt = damageDealt + opponentAttack.DoDamage() + opponentChar.DoDamage();

            //combo
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


    }
}
