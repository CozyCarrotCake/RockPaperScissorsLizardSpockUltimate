﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheCat : Assassin
    {
        public int bleed { get; protected set; } = 3;

        public TheCat()
        {
            name = "The Cat";


            combo += 0.15;

            whenPassive = 3;
        }


        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Combo + 0.15");
            Console.WriteLine("Passive: Bleed - Your enemies start to bleed after you win a round which hurts them for 3 rounds.");
                       
        }

        public override void Passive(Character otherChar, Attack yourAttack, Attack otherAttack, bool wonRound)
        {

            if (wonRound == true && bleed == 3)
            {
                Console.WriteLine("The Cat made " + otherChar.name + " start to bleed!");
            }


            if (bleed > 0)
            {
                Console.WriteLine(otherChar.name + " bled!");
                Console.ReadLine();
                otherChar.LostHealth = 2.5;
                bleed--;
            }
            else
            {
                bleed = 3;
            }
            
        }


    }
}
