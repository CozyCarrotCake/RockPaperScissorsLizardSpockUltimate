using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheCat : Assassin
    {
        public int bleed { get; protected set; }

        public TheCat()
        {
            name = "The Cat";


            combo += 0.15;
        }


        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Combo + 0.15");
            Console.WriteLine("Passive: Bleed - Your enemies gets hurt by a bleed for 3 rounds everytime you win a round.");
                       
        }

        public override void Passive(Character opponentChar)
        {
            base.Passive(opponentChar);

            if (bleed > 0)
            {
                Console.WriteLine("The opponent bled!");
                Console.ReadLine();
                opponentChar.LostHealth = 2.5;
                bleed--;
            }
            else
            {
                bleed = 2;
            }
            
        }


    }
}
