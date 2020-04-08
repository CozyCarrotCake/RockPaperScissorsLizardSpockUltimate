using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheQuick : Evader
    {
        public TheQuick()
        {
            name = "The Quick";


            combo += 0.15;

            whenPassive = 0;
        }


        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Combo + 0.15");
            Console.WriteLine("Passive: Fast Hands - Has a small chance of switching a losing hand into a draw");
        }

        public override void Passive(Character otherChar, Attack yourAttack, Attack otherAttack, bool wonRound)
        {

            Random quickGen = new Random();
            int quickPassive = quickGen.Next(100);
            
            if (Against < otherChar.Against)
            {
                if (quickPassive < 15)
                {
                    yourAttack = otherAttack;
                    Console.WriteLine("The Quick was fast enough to change his hand to a " + yourAttack.name + "!");
                }
                
            }
        }
    }
}
