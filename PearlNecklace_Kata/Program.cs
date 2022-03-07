using PearlNecklace_Kata;

var necklace1 = Pearl.Factory.CreateRandomNecklace();
Console.WriteLine(necklace1);
Console.WriteLine();
var testNecklace1 = new Pearl();
Console.WriteLine(testNecklace1);
Console.WriteLine();

var necklaceList = Necklace.Factory.CreateNecklaceList(100);
Console.WriteLine(necklaceList);
Console.WriteLine($"Amount of Pearls: {necklaceList.Count()}");
Console.WriteLine($"Amount of {PearlNecklace_Kata.Type.Freshwater} pearls: { necklaceList.NrOfEachType().freshCount}" +
    $"\nAmount of {PearlNecklace_Kata.Type.Saltwater} pearls: {necklaceList.NrOfEachType().saltCount}");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Sorted List");
necklaceList.Sort();
Console.WriteLine(necklaceList);
Console.WriteLine($"Total Price = {necklaceList.TotalPrice():C2}");

if (necklaceList.IndexOf(testNecklace1) == -1)
{
    Console.WriteLine("This necklace does NOT exist");
}
else
{
    Console.WriteLine(necklaceList.IndexOf(testNecklace1));
}

string filename = fname("PearlNecklace.txt");

using (FileStream fs = File.Create(filename))
using (TextWriter writer = new StreamWriter(fs))
{
	writer.WriteLine(necklaceList);
    Console.WriteLine();
    Console.WriteLine(filename);
}


using (FileStream fs = File.OpenRead(fname("PearlNecklace.txt")))
using (TextReader reader = new StreamReader(fs))
{
	Console.WriteLine(reader.ReadLine());
}

static string fname(string name)
{
	var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
	documentPath = Path.Combine(documentPath, "MyProjects", "Exercises");
	if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
	return Path.Combine(documentPath, name);
}