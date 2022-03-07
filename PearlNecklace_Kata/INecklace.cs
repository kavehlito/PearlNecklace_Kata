using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace_Kata
{
    internal interface INecklace
    {
        public IPearl this[int idx] { get; }
        int Count();
        void Sort();
        (int freshCount, int saltCount) NrOfEachType();
        public int IndexOf(IPearl pearl);
        public decimal TotalPrice();
    }
}
