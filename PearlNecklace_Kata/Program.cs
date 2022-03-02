using PearlNecklace_Kata;

var necklace1 = Pearl.Factory.CreateRandomNecklace();
Console.WriteLine(necklace1);
Console.WriteLine();
var testNecklace1 = new Pearl();
Console.WriteLine(testNecklace1);
Console.WriteLine();

var necklaceList = PearlList.Factory.CreateNecklaceList(100);
Console.WriteLine(necklaceList);
Console.WriteLine($"Amount of Necklaces: {necklaceList.Count()}");
Console.WriteLine($"Amount of {PearlNecklace_Kata.Type.Freshwater} necklaces: { necklaceList.NrOfEachType().freshCount}" +
    $"\nAmount of {PearlNecklace_Kata.Type.Saltwater} necklaces: {necklaceList.NrOfEachType().saltCount}");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Sorted List");
necklaceList.Sort();
Console.WriteLine(necklaceList);

Console.WriteLine(necklaceList.IndexOf(testNecklace1));