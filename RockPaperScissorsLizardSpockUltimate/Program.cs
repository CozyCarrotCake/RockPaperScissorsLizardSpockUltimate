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
            //Chosen Characters
            Character yourChar = new Character();
            List<Character> yourCharacters = new List<Character>();
            Character opponentChar = new Character();
            List<Character> opponentCharacters = new List<Character>();

            //List of the avaible Characters
            List<Character> characters = new List<Character>();
            characters.Add(new TheBoxer());
            characters.Add(new TheSledgehammer());
            characters.Add(new TheSniper());
            characters.Add(new TheCat());
            characters.Add(new TheShield());
            characters.Add(new TheBreaker());
            characters.Add(new TheQuick());
            //characters.Add(new TheSledgehammer());

            bool didWin;


            //The Methods

            Intro();

            yourCharacters = ChooseCharacter(yourCharacters, characters);

            opponentCharacters = RandomCharacter(opponentCharacters, characters);

            MatchUp(yourCharacters, opponentCharacters);

            didWin = Fight(yourCharacters, opponentCharacters);

            End(didWin);
            
            
            Console.ReadLine();
        }



        //Intro!
        static void Intro()
        {
            Console.WriteLine("Hello and welcome to TITLE");
            Console.ReadLine();
        }



        //Choosing CHaracters
        static List<Character> ChooseCharacter(List<Character> yourCharacters, List<Character> characters)
        {
            Console.Clear();
            Console.WriteLine("You will now choose your 3 fighters!");
            Console.WriteLine("Choose your FIRST fighter! Press the number of the character for its information!");
            Console.WriteLine("Your fighters:");
            Console.WriteLine("1. ");
            Console.WriteLine("2. ");
            Console.WriteLine("3. ");
            Console.WriteLine("");

            for (int i = 0; i < 7; i++)
            {

                Console.WriteLine();
                Console.WriteLine(i + 1 + ". " + characters[i].name);
                

            }


            string charSelection = Console.ReadLine();
            int charIndex;
            
            string[] yourCharactersNames = new string[3]; //Dont wanna deList
            

            while (1 == 1)
            {
                bool charSuccess = int.TryParse(charSelection, out charIndex);
                while (charSuccess == false || charIndex < 1 || charIndex > 8)
                {
                    Console.WriteLine("Please write the number of one of the characters!");
                    charSelection = Console.ReadLine();
                    charSuccess = int.TryParse(charSelection, out charIndex);

                }

                Console.Clear();
                Console.WriteLine("Your fighters:");
                Console.WriteLine("1. " + yourCharactersNames[0]);
                Console.WriteLine("2. " + yourCharactersNames[1]);
                Console.WriteLine("3. " + yourCharactersNames[2]);
                Console.WriteLine("");

                for (int i = 0; i < characters.Count; i++)
                {

                    Console.WriteLine();
                    Console.WriteLine(i + 1 + ". " + characters[i].name);
                    if (i == charIndex - 1)
                    {
                        characters[i].Info(i);
                    }

                }
                Console.WriteLine("");
                Console.WriteLine("Do you want to choose " + characters[charIndex-1].name + "? Press Enter!");
                Console.WriteLine("If you want to see another characters information Press their number!");

                charSelection = Console.ReadLine();
                if (charSelection == "")
                {
                    Console.Clear();

                    Character yourChar = characters[charIndex - 1];

                    Console.WriteLine("Allright you chose " + yourChar.name);
                    charIndex = 0;

                    characters.Remove(yourChar);
                    yourCharacters.Add(yourChar);

                    if (yourCharacters.Count == 1)
                    {
                        yourCharactersNames[0] = yourChar.name;
                        Console.WriteLine("Choose your SECOND fighter! Press the number of the character for its information!");

                    }
                    else if (yourCharacters.Count == 2)
                    {
                        yourCharactersNames[1] = yourChar.name;
                        Console.WriteLine("Choose your THIRD fighter! Press the number of the character for its information!");
                    }
                    else
                    {
                        yourCharactersNames[2] = yourChar.name;
                        break;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Your fighters:");
                    Console.WriteLine("1. " + yourCharactersNames[0]);
                    Console.WriteLine("2. " + yourCharactersNames[1]);
                    Console.WriteLine("3. " + yourCharactersNames[2]);
                    Console.WriteLine("");

                    for (int i = 0; i < characters.Count; i++)
                    {

                        Console.WriteLine();
                        Console.WriteLine(i + 1 + ". " + characters[i].name);
                        if (i == charIndex - 1)
                        {
                            characters[i].Info(i);
                        }

                    }

                    charSelection = Console.ReadLine();

                }
                

                
            }
            

            return yourCharacters;
        }

        
        static List<Character> RandomCharacter(List<Character> opponentCharacters, List<Character> characters)
        {

            Random charGen = new Random();

            for(int i = 0; i < 3; i++)
            {
                int charIndex = charGen.Next(0, characters.Count);
                opponentCharacters.Add(characters[charIndex]);
            }            

            return opponentCharacters;
        }


        //Just writes the teams
        static void MatchUp(List<Character> yourCharacters, List<Character> opponentCharacters)
        {
            Console.Clear();
            Console.WriteLine("Your Team:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(yourCharacters[i].name);
            }

            Console.WriteLine("");
            Console.WriteLine("Your Opponent's Team: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(opponentCharacters[i].name);
            }

            Console.WriteLine("");
            Console.WriteLine("Time to fight!");
            Console.ReadLine();
            Console.Clear();
        }



        // The Battle
        static bool Fight(List<Character> yourCharacters, List<Character> opponentCharacters)
        {
            bool didWin;

            double damageDealt = 10;

            int attackIndex = 0;
            Attack yourAttack = new Attack();
            Attack opponentAttack = new Attack();

            bool didChoose;

            int wOL;

            bool canDoBehavior = true;

            Character yourChar = yourCharacters[0];
            yourCharacters.Remove(yourChar);
            Character opponentChar = opponentCharacters[0];
            opponentCharacters.Remove(opponentChar);
            Console.WriteLine("First off, " + yourChar.name + " vs. " + opponentChar.name);


            while (1==1)
            {
                
                //Remaining HP
                Console.WriteLine("Your remaining HP: " + yourChar.hp);
                Console.WriteLine("Your opponents remaining HP: " + opponentChar.hp);



                //Choose Your Attack

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




                //Opponents Attack

                if (didChoose == true)
                {
                    //Make smart
                    Random opponentAttackGen = new Random();
                    attackIndex = opponentAttackGen.Next(1, 6);
                    opponentAttack = OpponentAttack(attackIndex);




                    // Attack UI

                    Console.WriteLine("You chose " + yourAttack.name);
                    Console.WriteLine("Your opponent chose " + opponentAttack.name);






                    //TRANSFORMATION

                    Console.WriteLine("");
                    Console.WriteLine("Do you wanna transform your attack?");

                    //Writes out and creates the attacks in the Classes



                    yourChar.BehaviorSpecial(canDoBehavior);
                    yourAttack.Transform();
                    yourAttack.Transformations(yourChar.Specials);
                    


                    //Choose transformation
                    string transform = Console.ReadLine();
                    int transformIndex;
                    bool transformSuccess = int.TryParse(transform, out transformIndex);
                    if (transformSuccess == false || transformIndex < 1 || transformIndex > 3)
                    {
                        Console.WriteLine("You chose not to transform!");
                    }
                    else if (canDoBehavior == true)
                    {
                        if (transformIndex == 1)
                        {
                            Console.WriteLine("You chose to transform your " + yourAttack.name + " into a " + yourChar.behaviorAttack.name);
                            yourAttack = yourChar.behaviorAttack;
                            canDoBehavior = false;
                        }
                    }
                    else if (yourChar.Specials > 0)
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
                    




                    // Enemy transformation
                    //Somethings wrong!!!!!
                    //Also make it thrice only!!!!

                    Random transformGen = new Random();
                    int transformInt = transformGen.Next(100);
                    if (transformInt < 25)
                    {
                        transformInt = transformGen.Next(0, 3);
                        if (transformInt == 0)
                        {
                            Console.WriteLine("Your enemy chose to transform their " + opponentAttack.name + " into a " + opponentChar.behaviorAttack.name);
                            opponentAttack = opponentChar.behaviorAttack;
                        }
                        else if (transformInt == 1)
                        {
                            Console.WriteLine("Your opponent chose to transform your " + opponentAttack.name + " into a " + opponentAttack.firstTransform.name);
                            opponentAttack = opponentAttack.firstTransform;
                        }
                        else
                        {
                            Console.WriteLine("Your opponent chose to transform your " + opponentAttack.name + " into a " + opponentAttack.secondTransform.name);
                            opponentAttack = opponentAttack.secondTransform;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your opponent chose not to transform!");
                    }
                    
                    

                }
                


                

                // Which attack wins
                wOL = WinOrLoose(attackIndex, yourAttack);


                // Deal the Damage
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
                
                Console.ReadLine();





                //If your fighter dies
                if (yourChar.hp < 0)
                {
                    Console.Clear();

                    if (yourCharacters.Count != 0)
                    {
                        Console.WriteLine(yourChar.name + " can no longer fight!");
                        yourChar = yourCharacters[0];
                        yourCharacters.Remove(yourChar);
                        Console.WriteLine(yourChar.name + " jumps in!");

                    }
                    else
                    {
                        Console.WriteLine("All your fighters are unable to continue!");
                        didWin = false;
                        break;
                    }

                    Console.ReadLine();
                }



                //If opponent fighter dies

                if (opponentChar.hp < 0)
                {
                    Console.Clear();

                    if (opponentCharacters.Count != 0)
                    {
                        Console.WriteLine(opponentChar.name + " can no longer fight!");
                        opponentChar = opponentCharacters[0];
                        opponentCharacters.Remove(opponentChar);
                        Console.WriteLine(opponentChar.name + " jumps in!");
                    }
                    else
                    {
                        Console.WriteLine("All your opponent's fighters are unable to continue!");
                        didWin = true;
                        break;
                    }

                    Console.ReadLine();  
                }

                Console.Clear();

            }

            return didWin;

        }





        //Choosing Attack


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

        static void TakeDamage(double damageDealt, Attack yourAttack, Attack opponentAttack, Character yourChar, Character opponentChar)
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





        //End

        static void End(bool didWin)
        {
            if(didWin == true)
            {
                Console.WriteLine("Yay you won!");
            }
            else
            {
                Console.WriteLine("Shit you lost loser!");
            }

        }

    }
}
