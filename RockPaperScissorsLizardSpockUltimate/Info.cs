using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class Info : Teams
    {
        public void IntroInfo()
        {
            //Körs också genom en while-loop som körs oändligt tills man väljer att backa till huvudmenyn genom en break
            while (1 == 1) 
            {
                Console.Clear();
                Console.WriteLine("INFO:");
                Console.WriteLine("1. General Information");
                Console.WriteLine();
                Console.WriteLine("2. The Fighters");
                Console.WriteLine();
                Console.WriteLine("3. The Attacks");
                Console.WriteLine();
                Console.WriteLine("4. Back");
                Console.WriteLine();

                //Ännu en tryparse-input-check
                string info = Console.ReadLine();
                int infoInt;
                bool infoSuccess = int.TryParse(info, out infoInt);
                while (infoSuccess == false || infoInt < 1 || infoInt > 4)
                {
                    Console.WriteLine("Please write the number of the alternative then press ENTER!");
                    info = Console.ReadLine();
                    infoSuccess = int.TryParse(info, out infoInt);
                }

                if (infoInt == 1)
                {
                    GenInfo();
                }
                else if (infoInt == 2)
                {
                    Fighters();
                }
                else if (infoInt == 3)
                {
                    Attacks();
                }
                else
                {
                    break;
                }
            }
            


        }


        //Generel Info om spelet och hur man spelar, ifall man vill förstå allt innan man hoppar in.
        public void GenInfo()
        {
            Console.Clear();
            Console.WriteLine("In this game you choose 3 of the availble Fighters to then battle an opponent who have their own team of Fighters!");
            Console.WriteLine("");
            Console.ReadLine();
            Console.WriteLine("The Fighters:");
            Console.WriteLine("Each Fighter is part of different classes, divided by Offensive and Defensive!");
            Console.WriteLine("Offense Fighters are in its step divided by Bruisers and Assassins, while Defensive are divided by Blockers and Evaders!");
            Console.WriteLine("Each Fighter has their own stats based on class and the Fighter themself, as well as having a passive to help them during battle!");
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine("The Battle:");
            Console.WriteLine("During the actual battle each Fighter gets to choose between one of the five Attacks each round!");
            Console.WriteLine("If your Attack beats the other Foghter's, you win the round and you deal damage to the opponent, and if the opposite they win and you take damage.");
            Console.WriteLine("By winning rounds the Fighters build up their combo score, which makes the upcoming winning rounds hit harder! But loosing a round depletes the combo meter!");
            Console.WriteLine("There's also a chance to crit on winning rounds, dealing additional damage!");
            Console.WriteLine("They will also be able to choose to transform their attack, with each attack having 2 specific transformations that will change the odds of the battle!");
            Console.WriteLine("You will also be able to transform your attack into an extremley powerful behavior attack, based on the Fighter being Offensive or Defensive.");
            Console.WriteLine("But remember! Transformations can only be used twice per character while behavior attacks only can be used ones every game!");
            Console.WriteLine();
            Console.ReadLine();
            Console.WriteLine("Every choice in the game can be made by writing the alternatives written number on the keyboard and then pressing ENTER.");
            Console.WriteLine("Practice this here by writing a number and then pressing ENTER to get back to the homescreen!");



            //Här kommer min favorit tryparse-check, där jag bara vill att spelaren övar på den svåra uppgiften att trycka på en siffra följt av ENTER. Finns ju ett par sådana
            //test som redan hänt men tänkte bara låta de veta att detta är det enda de kommer behöva göra
            string test = Console.ReadLine();
            int testInt;
            bool testSuccess = int.TryParse(test, out testInt);
            while (testSuccess == false)
            {
                Console.WriteLine("No! I said write a number and then press ENTER!");
                test = Console.ReadLine();
                testSuccess = int.TryParse(test, out testInt);
            }
        }


        //Info om alla fighters. Använder samma kodsystem som CHaracterPicker i hur den räknar upp karaktärerna och läser upp Info om karaktären spelaren valt.
        public void Fighters()
        {
            //charIndex skapas här uppe snarare än där nere vid resten av den klassiska string/int/bool skapelsen vid en tryparse-check då den även används i uppskrivningsloopen, 
            //även fast den den första gången den skrivs upp bara finns för att berätta loopen att ingen karaktär ska uppskrivas. 
            int charIndex = 0;
            while (1 == 1)
            {
               
                Console.Clear();

                //Denna for-loop skriver upp alla instanser av Karaktärer/Fighters i programCharacters, men kör även en karaktärs Info-metod om den blev vald i användarinputen
                //nedan förra loopen. Ingen är vald första gången de skrivs upp då if-satsen enbart körs om for--loopens i-variabel har samma värde som charIndex (-1), och då charIndex
                //har värdet 0 kommer inte detta hända
                Console.WriteLine("The Fighters:");
                for (int i = 0; i < programCharacters.Count; i++)
                {

                    Console.WriteLine();
                    Console.WriteLine(i + 1 + ". " + programCharacters[i].name);
                    if (i == charIndex - 1)
                    {
                        programCharacters[i].Info(i);
                    }
                    
                }

                Console.WriteLine();
                Console.WriteLine("9. Back");

                string charSelection = Console.ReadLine();
                bool charSuccess = int.TryParse(charSelection, out charIndex);
                while (charSuccess == false || charIndex < 1 || charIndex > 9)
                {
                    Console.WriteLine("Please write the number of one of the characters!");
                    charSelection = Console.ReadLine();
                    charSuccess = int.TryParse(charSelection, out charIndex);

                }
                Console.WriteLine();
                
                if(charIndex == 9)
                {
                    break;
                }

            }

            


        }


        //Info om alla Attacker
        public void Attacks()
        {
            //Skapar instanser av attackerna och lägger till de i en lista så att man ska kunna köra deras metoder som visar dess info.
            Console.Clear();
            List<Attack> attacks = new List<Attack>();
            Rock rock = new Rock();
            attacks.Add(rock);
            Paper paper = new Paper();
            attacks.Add(paper);
            Scissors scissors = new Scissors();
            attacks.Add(scissors);
            Lizard lizard = new Lizard();
            attacks.Add(lizard);
            Spock spock = new Spock();
            attacks.Add(spock);
            Snap snap = new Snap();
            attacks.Add(snap);
            Block block = new Block();
            attacks.Add(block);

            int attackIndex = 0;
            while (1 == 1)
            {

                Console.Clear();

                //Använder samma princip som vid karaktärerna, men instanserar även den valda attackens transformationer så att den kan visa info om de.
                Console.WriteLine("The Attacks:");
                for (int i = 0; i < 5; i++)
                {
                    
                    Console.WriteLine(i + 1 + ". " + attacks[i].name);
                    if (i == attackIndex - 1)
                    {
                        attacks[i].Info();
                        Console.WriteLine();
                        Console.WriteLine("Transformations: ");

                        attacks[i].Transform();
                        attacks[i].TransformationInfo();
                        
                    }
                    Console.WriteLine();
                }
                
                //Visar info om The Behavioral Transformations, samma princip som förrut men med mer matte i indexeringarna då deras relaterade siffror är högre
                Console.WriteLine("The Behavioral Transformations: ");
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(i + 6 + ". " + attacks[i+5].name);
                    if (i == attackIndex - 6)
                    {
                        attacks[i + 5].BehavioralInfo();
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("8. Go Back to Info Menu");

                string attackSelection = Console.ReadLine();
                bool attackSuccess = int.TryParse(attackSelection, out attackIndex);
                while (attackSuccess == false || attackIndex < 1 || attackIndex > 8)
                {
                    Console.WriteLine("Please write the number of one of the attacks!");
                    attackSelection = Console.ReadLine();
                    attackSuccess = int.TryParse(attackSelection, out attackIndex);

                }
                Console.WriteLine();

                if (attackIndex == 8)
                {
                    break;
                }

            }

        }

    }
}
