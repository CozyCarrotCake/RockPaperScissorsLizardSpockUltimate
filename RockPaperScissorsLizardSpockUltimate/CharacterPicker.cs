using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class CharacterPicker : Teams
    {

        //Choosing CHaracters

        

        public List<Character> Choose(List<Character> yourCharacters, List<Character> characters)
        {
            //Intro
            Console.Clear();
            Console.WriteLine("You will now choose your 3 fighters!");
            Console.WriteLine("Choose your FIRST fighter! Press the number of the character for its information!");
            Console.WriteLine("");
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

            //The first input
            string charSelection = Console.ReadLine();
            int charIndex;

            string[] yourCharactersNames = new string[3]; //Have to have an array to write all as the indexes doesn't exist in the lists yet.


            while (1 == 1) // Körs tills man valt alla 3
            {
                //Input checkaren körs alltid först, den första inputen togs ovanför och resten tas sist
                bool charSuccess = int.TryParse(charSelection, out charIndex);
                while (charSuccess == false || charIndex < 1 || charIndex > 8)
                {
                    Console.WriteLine("Please write the number of one of the characters!");
                    charSelection = Console.ReadLine();
                    charSuccess = int.TryParse(charSelection, out charIndex);

                }

                Console.Clear();

                //Det som står överst i fönstret
                Console.WriteLine("Do you want to choose " + characters[charIndex - 1].name + "? Press Enter!");
                Console.WriteLine("If you want to see another characters information Press their number!");
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
                Console.WriteLine("");


                charSelection = Console.ReadLine();

                //If you chose the character you picked before
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
                        break; // Only breaks the while when all characters have been chosen
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


    }
}
