using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace_Kata
{
    internal interface INecklaceList
    {
        public IPearlList this[int idx] { get;}
        int Count();
        void Sort();

    }
}
