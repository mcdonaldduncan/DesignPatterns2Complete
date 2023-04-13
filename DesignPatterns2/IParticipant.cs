using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2
{
    public interface IParticipant
    {
        string Name { get; set; }
        Uniform UniformColor { get; set; }
        string GemStone { get; set; }
        List<Item> Inventory { get; set; }
        int TurnsRemaining { get; set; }

        void Update(ItchyEyeDebuff debuff);
    }
}
