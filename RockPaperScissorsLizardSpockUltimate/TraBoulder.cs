using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraBoulder : Rock
    {
        public TraBoulder()
        {
            name = "Boulder";

            transPaper = true;
            transRock = true;
            transDmg = true;

            TransformStats();
        }


    }
}
