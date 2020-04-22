using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockUltimate
{
    class TraTurtle : Lizard
    {
        public TraTurtle()
        {
            name = "Turtle";

            transPaper = true;
            transRock = true;
            transDef = true;
        }
    }
}
