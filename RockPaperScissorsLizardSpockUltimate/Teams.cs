using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Teams
    {

        protected List<Character> programCharacters = new List<Character>();

        public Teams()
        {
            //List of the avaible Characters
            programCharacters.Add(new TheBoxer());
            programCharacters.Add(new TheSledgehammer());
            programCharacters.Add(new TheSniper());
            programCharacters.Add(new TheCat());
            programCharacters.Add(new TheShield());
            programCharacters.Add(new TheBreaker());
            programCharacters.Add(new TheQuick());
            programCharacters.Add(new TheInvisible());
        }


        //Just writes the teams
        public void MatchUp(List<Character> yourCharacters, List<Character> opponentCharacters, int singleRounds)
        {
            

            Console.Clear();
            Console.WriteLine("Your Team:");
            for (int i = 0; i < singleRounds; i++)
            {
                Console.WriteLine(yourCharacters[i].name);
            }

            Console.WriteLine("");
            Console.WriteLine("Your Opponent's Team: ");
            for (int i = 0; i < singleRounds; i++)
            {
                Console.WriteLine(opponentCharacters[i].name);
            }

            Console.ReadLine();
            Console.Clear();
        }

    }
}
