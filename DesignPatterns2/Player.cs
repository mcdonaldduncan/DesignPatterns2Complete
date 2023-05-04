using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns2
{
    public class Player : ParticipantPoco
    {
        public Player()
        {
            Inventory = new List<Item>();
        }

        public string DisplayInventory()
        {
            string output = "";

            foreach (var item in Inventory)
            {
                output += item.Name + Environment.NewLine;
            }

            return output;
        }
    }
}
