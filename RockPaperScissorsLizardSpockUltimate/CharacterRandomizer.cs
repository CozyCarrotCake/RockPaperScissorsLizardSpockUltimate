using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class CharacterRandomizer
    {

        public List<Character> Randomizer(List<Character> opponentCharacters, List<Character> characters)
        {
            Random charGen = new Random();

            for (int i = 0; i < 3; i++)
            {
                int charIndex = charGen.Next(0, characters.Count);
                opponentCharacters.Add(characters[charIndex]);
                characters.Remove(characters[charIndex]);
            }

            return opponentCharacters;
        }
    }
}
