namespace PearlNecklace_Kata
{
    internal class PearlList : IPearlList
    {
        List<IPearl> _pearlList = new List<IPearl>();
        public IPearl this[int idx]
        {
            get { return _pearlList[idx]; }
        }
        public override string ToString()
        {
            string sRet = "";
            int pearlNum = 1;
            for (int i = 0; i < _pearlList.Count; i++)
            {
                sRet += $"Pearl #{pearlNum}: {_pearlList[i]}\n";
                //if ((i + 1) % 10 == 0)
                {
                    //     sRet += "\n";
                }
                pearlNum++;
            }
            return sRet;
        }
        public int Count() => _pearlList.Count;

        public (int freshCount, int saltCount) NrOfEachType()
        {
            int freshWaterCount = 0;
            int saltWaterCount = 0;
            for (int i = 0; i < _pearlList.Count; i++)
            {
                if (_pearlList[i].Type == Type.Freshwater)
                {
                    freshWaterCount++;
                }

                if (_pearlList[i].Type == Type.Saltwater)
                {
                    saltWaterCount++;
                }
            }
            return (freshWaterCount, saltWaterCount);
        }
        public void Sort() => _pearlList.Sort();

        public int IndexOf(IPearl pearl) => _pearlList.IndexOf(pearl);

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in _pearlList)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }

        public int NumberOfBlackPearls()
        {
            int NrOfBlackPearls = 0;
            for (int i = 0; i < _pearlList.Count; i++)
            {
                if (_pearlList[i].Color == Color.Black)
                {
                    NrOfBlackPearls++;
                }
            }
            return NrOfBlackPearls;
        }

        internal static class Factory
        {
            internal static IPearlList CreateNecklace(int NrOfNecklaces)
            {
                var pearList = new PearlList();
                for (int i = 0; i < NrOfNecklaces; i++)
                {
                    pearList._pearlList.Add(Pearl.Factory.CreateRandomNecklace());
                }
                return pearList;
            }
        }
        public PearlList() { }
    }
}
