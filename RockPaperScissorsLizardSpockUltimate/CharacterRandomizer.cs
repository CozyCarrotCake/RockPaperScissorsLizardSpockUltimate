using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class CharacterRandomizer : Teams
    { 

        public List<Character> Randomizer(List<Character> opponentCharacters, List<Character> characters)
        {
            Random charGen = new Random();

            HashSet<Character> hashCharacters = new HashSet<Character>();

            for (int i = 1; i < 4; i++)
            {
                int charIndex = charGen.Next(0, characters.Count);

                while (hashCharacters.Count != i)
                {
                    hashCharacters.Add(characters[charIndex]);
                    if (hashCharacters.Count != i)
                    {
                        charIndex = charGen.Next(0, characters.Count);
                    }
                    
                }

                opponentCharacters.Add(characters[charIndex]);
                
            }

            return opponentCharacters;
        }
    }
}
