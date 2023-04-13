using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DesignPatterns2.Constant;

namespace DesignPatterns2
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private int maxEffect = 5;

        public override string ToString()
        {
            return Name;
        }

        public int GetEffect()
        {
            return R.Next(maxEffect);
        }
    }
}
