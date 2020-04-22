using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class CharacterPicker : Teams
    {

        //Choosing Characters
        public int charIndex = 0;
        string charSelection = "";

        //Have to have an array to write the chosen characters names as the indexes doesn't exist in the lists yet and causes the game to crash
        string[] yourCharactersNames = new string[3];


        //Låter spelaren välja sin/sina karaktärer
        public List<Character> Choose(List<Character> yourCharacters, int singleRounds)
        {
            //gör en kopia på listan som skapades i Team-instansen så att jag kan ta bort karaktärer ur den utan att de försvinner från hela spelet
            List<Character> characters = new List<Character>(programCharacters);


            
            Console.Clear();
            Console.WriteLine("You will now choose your 3 fighters!");
            Console.WriteLine("Choose your FIRST fighter! Press the number of the character for its information!");


            //En metod som skriver upp Spelarens valda karaktärer och hur många man kommer behöva välja
            YourFighters(singleRounds);


            
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


                YourFighters(singleRounds);

                WriteTheCharacters(characters);
                                


                //Kollar om man väljer indexet av en ny karaktär eller om man bestämde sig för den man hade
                charSelection = Console.ReadLine();




                //Om man tryckte enter så bestämde man sig, annars körs loopen om med det index man precis valde
                if (charSelection == "")
                {
                    Console.Clear();

                    //Den valda karaktären instanseras genom charIndex som man valde
                    Character yourChar = characters[charIndex - 1];

                    Console.WriteLine("Allright you chose " + yourChar.name);

                    //CharIndex blir 0 för att inte köra någon annan karaktärs info direkt
                    charIndex = 0;


                    //Tar bort karaktären från listan så att man inte kan välja samma två gånger
                    characters.Remove(yourChar);

                    //lägger till karaktären i listan som returneras och används till själva fighten
                    yourCharacters.Add(yourChar);

                    
                    //Gränssnitt för om man ska välja fler karaktärer.
                    if (singleRounds == 3)
                    {
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

                        YourFighters(singleRounds);
                    }
                    else
                    {
                        break;
                    }
                    


                    //Skriver upp karaktärererna och tar input igen om man valde en karaktär förra gången

                    WriteTheCharacters(characters);

                    charSelection = Console.ReadLine();
                }



            }


            return yourCharacters;
        }

        //Skriver ut alla karaktärer med hjälp av en for-loop, och ifall spelar valt någon genom dess input som kommer senare kör den karaktärens Info-klass-metod. 
        //Körs inte första gången då charIndex har värdet 0 innan användarinputen.
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

        //Skriver ut de karaktärer man valt, visar upp andra delen om man kör modet där man har 3 fighters
        public void YourFighters(int singleRounds)
        {
            Console.WriteLine("");
            Console.WriteLine("Your fighters:");
            Console.WriteLine("1. " + yourCharactersNames[0]);

            if(singleRounds == 3)
            {
                Console.WriteLine("2. " + yourCharactersNames[1]);
                Console.WriteLine("3. " + yourCharactersNames[2]);
            }
            
        }
    }
}
