using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns2.Constant;

namespace DesignPatterns2
{
    public class Competitor : Participant
    {
        public Competitor()
        {
            Name = "The Stare Master";
            UniformColor = UniformColors[R.Next(UniformColors.Count)];
            GemStone = GemBank[R.Next(GemBank.Count)];
            TurnsRemaining = R.Next(10, 20);
        }
    }
}
