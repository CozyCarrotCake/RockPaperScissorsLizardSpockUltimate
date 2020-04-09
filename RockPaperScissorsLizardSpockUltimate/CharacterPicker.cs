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
        public int charIndex = 0;
        string charSelection = "";

        //Have to have an array to write all as the indexes doesn't exist in the lists yet.
        string[] yourCharactersNames = new string[3];



        public List<Character> Choose(List<Character> yourCharacters, List<Character> programCharacters)
        {
            //So that they only dissapear here, but doesn't?
            List<Character> characters = programCharacters;


            //Intro
            Console.Clear();
            Console.WriteLine("You will now choose your 3 fighters!");
            Console.WriteLine("Choose your FIRST fighter! Press the number of the character for its information!");

            YourFighters();


            WriteTheCharacters(characters);



            charSelection = Console.ReadLine();


            // Loop som körs tills man valt alla 3, break
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

                //Det som står överst i fönstret
                Console.WriteLine("Do you want to choose " + characters[charIndex - 1].name + "? Press Enter!");
                Console.WriteLine("If you want to see another characters information Press their number!");


                YourFighters();

                WriteTheCharacters(characters);
                                


                //Kollar om man väljer en ny karaktär eller om man bestämde sig för den man hade
                charSelection = Console.ReadLine();




                //Om man tryckte enter så bestämde man sig, annars körs loopen om
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


                    YourFighters();

                    WriteTheCharacters(characters);

                    charSelection = Console.ReadLine();
                }



            }


            return yourCharacters;
        }

        //Skriver ut alla karaktärer
        public void WriteTheCharacters(List <Character> characters)
        {
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
        }

        //Skriver ut de karaktärer man valt
        public void YourFighters()
        {
            Console.WriteLine("");
            Console.WriteLine("Your fighters:");
            Console.WriteLine("1. " + yourCharactersNames[0]);
            Console.WriteLine("2. " + yourCharactersNames[1]);
            Console.WriteLine("3. " + yourCharactersNames[2]);
        }
    }
}
