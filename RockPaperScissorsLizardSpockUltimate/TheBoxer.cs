using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheBoxer : Bruiser
    {
        public TheBoxer()
        {
            name = "The Boxer";
            
            combo += 0.15;

            whenPassive = 3;
        }

        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Combo + 0.15");
            Console.WriteLine("Passive: Absorber - Starts building up combo on enemy hits after enemy has had a streak of 2");
        }


        public override void Passive(Character otherChar, Attack yourAttack, Attack otherAttack, bool wonRound)
        {

            if (otherChar.Streak > 1)
            {
                Console.WriteLine("The Breaker has started to build his combo!");
                Streak = 1;
                double comboValue = Math.Pow((yourAttack.combo * combo), Streak);
                Console.WriteLine("Your Combo Bonus: " + comboValue);
            }
        }

    }
}
