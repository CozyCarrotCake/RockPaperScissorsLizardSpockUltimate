using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class CharacterRandomizer : Teams
    { 

        public List<Character> Randomizer(List<Character> opponentCharacters, List<Character> yourCharacters, int singleRounds)
        {
            Random charGen = new Random();

            //Använder en HashSet för att checka om karaktären redan valts till listan eller inte
            HashSet<Character> hashCharacters = new HashSet<Character>();


            //Kopierar såsom characterPicker
            List<Character> characters = new List<Character>(programCharacters);


            //Removes the fighters the player has chosen, plays once if its a Quick Smash and thrice if its the other mode
            for (int i = 1; i < singleRounds+1; i++)
            {
                //WHY THIS NO WORK
                Character yourChar = yourCharacters[i-1];
                characters.Remove(yourChar);
            }

            Console.Clear();
            for (int i = 0; i < characters.Count; i++)
            {
                Console.WriteLine(characters[i].name);
            }
            Console.ReadLine();


            for (int i = 1; i < singleRounds+1; i++)
            {
                //Slump yao
                int charIndex = charGen.Next(0, characters.Count + 1);

                //Körs tills en karaktär har lagts till i HashSeten och den då har lika många karaktärer som for-loopens i-värde 
                while (hashCharacters.Count != i)
                {
                    //Prövar att lägga till karaktären i Hashen
                    hashCharacters.Add(characters[charIndex]);

                    //Om karaktären redan fanns med i Hashen och den därav inte har lika stort värde som for-loopens i-värde slumpas charIndex igen för att fortsätta while-loopen
                    if (hashCharacters.Count != i)
                    {
                        charIndex = charGen.Next(0, characters.Count);
                    }
                    
                }

                //den listan som returneras och används i fighten, karaktären läggs bara till om den lagts till i Hashen och alltså inte är en dubblett.
                opponentCharacters.Add(characters[charIndex]);
                
            }

            return opponentCharacters;
        }
    }
}
