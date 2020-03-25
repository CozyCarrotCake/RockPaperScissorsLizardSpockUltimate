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

            againstPaper += 1;
            againstRock += 1;
            defense += 20;
        }
    }
}
