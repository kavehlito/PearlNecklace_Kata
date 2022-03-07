namespace PearlNecklace_Kata
{
    internal class NecklaceList : INecklaceList
    {
        List<IPearlList> _necklaceList = new List<IPearlList>();
        public IPearlList this[int idx] => _necklaceList[idx];

        public override string ToString()
        {
            string sRet = "";
            int pearlNum = 1;
            for (int i = 0; i < _necklaceList.Count; i++)
            {
                sRet += $"\nNecklace #{pearlNum}:  \n{_necklaceList[i]}";
                sRet += $"\nNecklace #{pearlNum} contains {_necklaceList[i].Count()} pearls";
                sRet += $"\nTotal Price for Necklace #{pearlNum} is: {_necklaceList[i].TotalPrice():C2}\n";
                pearlNum++;
            }
            return sRet;
        }
        public int Count() => _necklaceList.Count();

        public void Sort() => _necklaceList.Sort();

        internal static class Factory
        {
            internal static NecklaceList CreateNecklanceList(int amount)
            {
                var rnd = new Random();
                var necklaceList = new NecklaceList();
                for (int i = 0; i < amount; i++)
                {
                    var randomAmountOfPealrs = rnd.Next(5, 51);
                    necklaceList._necklaceList.Add(PearlList.Factory.CreateNecklace(randomAmountOfPealrs));
                }
                return necklaceList;
            }
        }
        public NecklaceList() { }
    }
}
