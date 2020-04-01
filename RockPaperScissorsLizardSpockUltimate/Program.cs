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
            //characters.Add(new TheSledgehammer());

            bool didWin;


            

            Intro();

            
           

            CharacterPicker characterPicker = new CharacterPicker();
            yourCharacters = characterPicker.Choose(yourCharacters, characters);


            CharacterRandomizer characterRandomizer = new CharacterRandomizer();
            opponentCharacters = characterRandomizer.Randomizer(opponentCharacters, characters);


            Teams teams = new Teams();
            teams.MatchUp(yourCharacters, opponentCharacters);


            Battle battle = new Battle();
            didWin = battle.Fight(yourCharacters, opponentCharacters);


            End(didWin);
            
            
            Console.ReadLine();
        }



        //Intro!
        static void Intro()
        {
            Console.WriteLine("Hello and welcome to TITLE");
            Console.ReadLine();
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

        }

    }
}
