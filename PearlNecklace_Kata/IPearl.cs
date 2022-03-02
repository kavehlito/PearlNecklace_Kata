using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace_Kata
{
    public enum Color { Pink, Blue, Yellow, Black, White}
    public enum Shape { Round, Square, Teardrop}
    public enum Type { Freshwater, Saltwater}
    internal interface IPearl : IComparable<IPearl>, IEquatable<IPearl>
    {
        public Color Color { get; set; }
        public Shape Shape { get; set; }
        public Type Type { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
        public void RandomInit();
    }
}
