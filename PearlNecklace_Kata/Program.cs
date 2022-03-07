using PearlNecklace_Kata;

var necklace1 = Pearl.Factory.CreateRandomNecklace();
Console.WriteLine(necklace1);
Console.WriteLine();
var testNecklace1 = new Pearl();
Console.WriteLine(testNecklace1);
Console.WriteLine();

var pearlList = PearlList.Factory.CreateNecklace(50);
Console.WriteLine(pearlList);
Console.WriteLine($"Amount of Pearls: {pearlList.Count()}");
Console.WriteLine($"Amount of {PearlNecklace_Kata.Type.Freshwater} pearls: { pearlList.NrOfEachType().freshCount}" +
    $"\nAmount of {PearlNecklace_Kata.Type.Saltwater} pearls: {pearlList.NrOfEachType().saltCount}");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Sorted List");
pearlList.Sort();
Console.WriteLine(pearlList);
Console.WriteLine($"Total Price = {pearlList.TotalPrice():C2}");

if (pearlList.IndexOf(testNecklace1) == -1)
{
    Console.WriteLine("This necklace does NOT exist");
}
else
{
    Console.WriteLine(pearlList.IndexOf(testNecklace1)+1);
}

var listOfNecklaces = NecklaceList.Factory.CreateNecklanceList(10);
Console.WriteLine();
Console.WriteLine("----------------------------------------");
Console.WriteLine(listOfNecklaces);
Console.WriteLine("----------------------------------------");

/*
string filename = fname("PearlNecklace.txt");

using (FileStream fs = File.Create(filename))
using (TextWriter writer = new StreamWriter(fs))
{
	writer.WriteLine(pearlList);
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
*/
string boxOfNecklaces = bname("BoxOfNecklaces.txt");

using (FileStream fs = File.Create(boxOfNecklaces))
using (TextWriter writer = new StreamWriter(fs))
{
	writer.WriteLine(listOfNecklaces);
    Console.WriteLine();
    Console.WriteLine(boxOfNecklaces);
}


using (FileStream fs = File.OpenRead(bname("BoxOfNecklaces.txt")))
using (TextReader reader = new StreamReader(fs))
{
	Console.WriteLine(reader.ReadLine());
}

static string bname(string name)
{
	var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
	documentPath = Path.Combine(documentPath, "MyProjects", "Exercises");
	if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
	return Path.Combine(documentPath, name);
}