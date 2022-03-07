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
        public Color Color { get;}
        public Shape Shape { get;}
        public Type Type { get;}
        public int Size { get;}
        public decimal Price { get;}
        public void RandomInit();
    }
}
