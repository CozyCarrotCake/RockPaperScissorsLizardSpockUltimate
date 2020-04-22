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

            //Variabeln används för att spara värdet av spelarens val i intro-menyn
            int introInt;


            //Teams-instansen skapas här då den skapar listan med alla karaktärer och lägger till instanserna av karaktärerna i den. 
            Teams teams = new Teams();


            //Loopen som hela spelet körs i, körs oändligt tills spelaren väljer "Quit Game" i menyn.
            while (1 == 1) 
            {
                introInt = Intro();

                

                if (introInt == 1)
                {
                    //Tar en till SinglePlayer klassen och dess huvudmetod
                    SinglePlayer singlePlayer = new SinglePlayer();
                    singlePlayer.SinglePlay(teams);
                }
                else if (introInt == 2)
                {
                    //Multiplayer har jag inte lyckats lägga till då det skulle behövas lite API-programmering för det som jag för tillfället inte kunnat/ orkat göra.
                    Console.WriteLine("Sorry Multiplayer is still being assembled!");
                    Console.ReadLine();
                }
                else if (introInt == 3)
                {
                    //Tar en till The Info Hub!!! 
                    Info info = new Info();
                    info.IntroInfo();
                }
                else
                {
                    //Om man av någon anledning vill sluta spela detta fantastiska spel
                    break;

                }
            }
            
        }



        //Intro, skriver bara ut huvudmenyn och tar den första andvändarinputen och felsöker den genom en tryParse-och-variabelvärde-check med trevlig liten while-loop 
        //för att se till att man gör rätt
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
            Console.WriteLine("4. Quit Game");
            
            //Finns många av dessa tryparse-checkar då typ varje typ av användarinput är genom val av siffror.
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

        
        
            
            
        

    }
}
