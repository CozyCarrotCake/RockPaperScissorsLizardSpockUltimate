using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Program
    {
        static void Main(string[] args)
        {
            //Chosen Characters
            List<Character> yourCharacters = new List<Character>();
            List<Character> opponentCharacters = new List<Character>();

            List<Character> characters = new List<Character>();

            //List of the avaible Characters
            characters.Add(new TheBoxer());
            characters.Add(new TheSledgehammer());
            characters.Add(new TheSniper());
            characters.Add(new TheCat());
            characters.Add(new TheShield());
            characters.Add(new TheBreaker());
            characters.Add(new TheQuick());
            characters.Add(new TheInvisible());

            bool didWin = false;

            int introInt;

            
            while (1== 1)
            {
                introInt = Intro();

                

                if (introInt == 1)
                {
                    SinglePlayer(yourCharacters, opponentCharacters, characters, didWin);
                }
                else if (introInt == 2)
                {
                    Console.WriteLine("Sorry Multiplayer is still being assembled!");
                    Console.ReadLine();
                }
                else if (introInt == 3)
                {
                    Info info = new Info();
                    info.IntroInfo(characters);
                }
                else
                {
                    break;

                }
            }
            
        }



        //Intro!
        static int Intro()
        {

            Console.Clear();


            Console.WriteLine("Hello and welcome to NAME, the new version of the classic Rock, Paper, Scissors, Lizard, Spock!");
            Console.ReadLine();

            Console.WriteLine("1. Single Player");
            Console.WriteLine();
            Console.WriteLine("2. Multi Player");
            Console.WriteLine();
            Console.WriteLine("3. Info");
            Console.WriteLine();
            Console.WriteLine("4. Quit");
            

            string introPick = Console.ReadLine();
            int introInt;
            bool introSuccess = int.TryParse(introPick, out introInt);
            while (introSuccess == false || introInt < 1 || introInt > 4)
            {
                Console.WriteLine("Please pick one of the alternatives above by pressing it's specified number followed by ENTER!");

                introPick = Console.ReadLine();
                introSuccess = int.TryParse(introPick, out introInt);
            }

            Console.Clear();

            return introInt;
        }


        static void SinglePlayer(List<Character> yourCharacters, List<Character> opponentCharacters, List<Character> characters, bool didWin )
        {
            CharacterPicker characterPicker = new CharacterPicker();
            yourCharacters = characterPicker.Choose(yourCharacters, characters);

            Console.WriteLine(characters.Count);
            Console.ReadLine();

            CharacterRandomizer characterRandomizer = new CharacterRandomizer();
            opponentCharacters = characterRandomizer.Randomizer(opponentCharacters, characters);

            
            Teams teams = new Teams();
            teams.MatchUp(yourCharacters, opponentCharacters);


            Battle battle = new Battle();
            didWin = battle.Fight(yourCharacters, opponentCharacters);


            End(didWin);
        }
        

        //Timer - nOt used for now
        /*static void Timer_Elapsed(Object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("3...");
        }
        */

            
            
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

            Console.ReadLine();
        }

    }
}
