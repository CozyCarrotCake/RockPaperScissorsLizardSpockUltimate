using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Teams
    {

        //Just writes the teams
        public void MatchUp(List<Character> yourCharacters, List<Character> opponentCharacters)
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

    }
}
