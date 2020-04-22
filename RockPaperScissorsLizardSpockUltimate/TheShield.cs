using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TheShield : Blocker
    {
        public TheShield()
        {
            name = "The Shield";

            defense *= 1.2;

            whenPassive = 3;
        }

        public override void Info(int Index)
        {
            base.Info(Index);

            Console.WriteLine("Defense + 20%");
            Console.WriteLine("Passive: Hitting Metal - The Opponent has a small chance of taking damage when dealing damage to you");

        }

        public override void Passive(Character otherChar, Attack yourAttack, Attack otherAttack)
        {
            Random shieldGen = new Random();
            int shieldPas = shieldGen.Next(100);

            if (Against < otherChar.Against && shieldPas < 15)
            {
                otherChar.LostHealth = 5;
            }
        }
    }
}
