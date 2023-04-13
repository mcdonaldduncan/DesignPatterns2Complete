using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesignPatterns2
{
    public class Constant
    {
        public static List<Uniform> UniformColors = new List<Uniform>()
        {
            new Uniform() {Name="Black", Brush=Brushes.Black},
            new Uniform() {Name="Red", Brush=Brushes.Red},
            new Uniform() {Name="Green", Brush=Brushes.Green},
            new Uniform() {Name="Blue", Brush=Brushes.Blue}
        };


        public static List<Item> ItemBank = new List<Item>()
        {
            new Item() {Name="Eyeglasses"},
            new Item() {Name="Stetson Hat"},
            new Item() {Name="Pain Killers"},
            new Item() {Name="Living Water of Mandalore"}
        };

        public static List<string> GemBank = new List<string>()
        {
            "Diamond",
            "Sapphire",
            "Emerald",
            "Ruby",
            "Opal"
        };

        public static Random R = new Random();
    }
}
