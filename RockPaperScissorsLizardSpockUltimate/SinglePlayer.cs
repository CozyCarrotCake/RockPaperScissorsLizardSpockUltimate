using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class SinglePlayer
    {
        //Kör hela singleplayer matcherna, typ som en hub

        //Skapar listorna som spelaren och datorns karaktärer ska läggas in i
        List<Character> yourCharacters = new List<Character>();
        List<Character> opponentCharacters = new List<Character>();

        

        //Om man vann matchen eller inte
        bool didWin = false;


        //Huvudmetoden
        public void SinglePlay(Teams teams)
        {
            //Välj mode, 1 fighter eller 3 fighters, eller tillbaka till huvudmenyn 
            Console.WriteLine("Which mode would you like to play?");
            Console.WriteLine();
            Console.WriteLine("1. Fast Smash - A fast game with only one fighter and life per side.");
            Console.WriteLine();
            Console.WriteLine("2. A Little Bit Longer Smash - A kinda long game with 3 fighters with one life each per team.");
            Console.WriteLine();
            Console.WriteLine("3. Back - Not ready for the single life huh?");
            string singleMode = Console.ReadLine();
            int singleRounds;

            bool singleSuccess = int.TryParse(singleMode, out singleRounds);
            while (singleSuccess == false || singleRounds < 1 || singleRounds > 3)
            {
                Console.WriteLine("Please write the number of the mode you want to play");
                singleMode = Console.ReadLine();
                singleSuccess = int.TryParse(singleMode, out singleRounds);
            }

            //Om man inte valde att backa
            if (singleRounds != 3)
            {
                //Då jag använder singleRounds-variabeln för att bestämma antal karaktärer i fighten gör jag tvåan till en trea, då det är tre fighters i moden. 
                if (singleRounds == 2)
                {
                    singleRounds = 3; 
                }

                //Instansierar och kör characterPicker-klassens huvudmetod, som låter spelaren välja sina karaktärer
                CharacterPicker characterPicker = new CharacterPicker();
                yourCharacters = characterPicker.Choose(yourCharacters, singleRounds);

                //Instansierar och kör characterRandomizer-klassens huvudmetod, som låter datorn slumpa fram sina karaktärer
                CharacterRandomizer characterRandomizer = new CharacterRandomizer();
                opponentCharacters = characterRandomizer.Randomizer(opponentCharacters, yourCharacters, singleRounds);

                //Om man valde modet med flera fighters körs en metod i team-klassen som bara listar upp spelarens och datorns line-up, behövs inte när båda bara har en karaktär.
                if (singleRounds != 1)
                {
                    teams.MatchUp(yourCharacters, opponentCharacters, singleRounds);
                }

                //Själva fighten, som körs i battle-instansen
                Battle battle = new Battle();
                didWin = battle.Fight(yourCharacters, opponentCharacters);

                //Spelar upp slut-metoden som bara säger om man vann eller inte
                End(didWin);

            }
            else
            {
                //Tar en tillbaka till huvudmenyn i Program
            }
        }




        //End
        void End(bool didWin)
        {
            if (didWin == true)
            {
                Console.WriteLine("Yay you won!");
            }
            else
            {
                Console.WriteLine("Shit you lost loser!");
            }

            Console.ReadLine();
        }
    }
}
