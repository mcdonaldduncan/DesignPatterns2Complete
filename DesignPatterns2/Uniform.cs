using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesignPatterns2
{
    public class Uniform
    {
        public string Name { get; set; }
        public Brush Brush { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
