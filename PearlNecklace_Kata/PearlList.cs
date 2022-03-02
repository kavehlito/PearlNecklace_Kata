using PearlNecklace_Kata;
namespace PearlNecklace_Kata
{
    internal class PearlList : IPearlList
    {
        List<IPearl> _necklaceList = new List<IPearl>();
        public IPearl this[int idx]
        {
            get { return _necklaceList[idx]; }
        }
        public override string ToString()
        {
            string sRet = "";
            int pearlNum = 0;
            for (int i = 0; i < _necklaceList.Count; i++)
            {
                sRet += $"Pearl #{pearlNum}:  {_necklaceList[i]}\n";
                if ((i + 1) % 10 == 0)
                {
                    sRet += "\n";
                }
                pearlNum++;
            }
            return sRet;
        }
        public int Count() => _necklaceList.Count;

        public (int freshCount, int saltCount) NrOfEachType()
        {
            int freshWaterCount = 0;
            int saltWaterCount = 0;
            for (int i = 0; i < _necklaceList.Count; i++)
            {
                if (_necklaceList[i].Type == Type.Freshwater)
                {
                    freshWaterCount++;
                }

                if (_necklaceList[i].Type == Type.Saltwater)
                {
                    saltWaterCount++;
                }
            }
            return (freshWaterCount, saltWaterCount);
        }
        public void Sort() => _necklaceList.Sort();

        public int IndexOf(IPearl pearl) => _necklaceList.IndexOf(pearl);

        internal static class Factory
        {
            internal static IPearlList CreateNecklaceList(int NrOfNecklaces)
            {
                var pearList = new PearlList();
                for (int i = 0; i < NrOfNecklaces; i++)
                {
                    pearList._necklaceList.Add(Pearl.Factory.CreateRandomNecklace());
                }
                return pearList;
            }
        }
        public PearlList() { }
    }
}
