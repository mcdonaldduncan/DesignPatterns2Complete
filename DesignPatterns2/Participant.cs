using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2
{
    public class Participant : IParticipant
    {
        [ParticipantName]
        public string Name { get; set; }

        [CustomRequired]
        public Uniform UniformColor { get; set; }

        public string GemStone { get; set; }

        [ListSize(Size = 2)]
        [UniqueCollection]
        public List<Item> Inventory { get; set; }

        public int TurnsRemaining { get; set; } = 15;

        public void Update(ItchyEyeDebuff debuff)
        {
            TurnsRemaining -= debuff.Strength;
        }
    }
}
