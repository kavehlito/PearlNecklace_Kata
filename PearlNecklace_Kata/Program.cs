using PearlNecklace_Kata;
using System.Diagnostics;
using System.IO.Compression;

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
    Console.WriteLine(pearlList.IndexOf(testNecklace1) + 1);
}

var listOfNecklaces = NecklaceList.Factory.CreateNecklanceList(1000);
Console.WriteLine();
Console.WriteLine("----------------------------------------");
//Console.WriteLine(listOfNecklaces);
Console.WriteLine("----------------------------------------");
Console.WriteLine($"Total price Box of necklaces: {listOfNecklaces.TotalNecklaceBoxPrice():C2}");
Console.WriteLine($"Total amount of black pearls: {listOfNecklaces.TotalNumberOfBlackPearls()}\n");
Console.WriteLine();

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
    writer.WriteLine($"{listOfNecklaces}\nTotal price Box of necklaces: {listOfNecklaces.TotalNecklaceBoxPrice():C2}" +
        $"\nTotal amount of black pearls: {listOfNecklaces.TotalNumberOfBlackPearls()}");
    Console.WriteLine();
    Console.WriteLine(boxOfNecklaces);
}


using (FileStream fs = File.OpenRead(bname("BoxOfNecklaces.txt")))
using (TextReader reader = new StreamReader(fs))
{
    Console.WriteLine(reader.ReadLine());
}


using (Stream s = File.Create(bname("BoxOfNecklaces_uncompressed.text")))
using (TextWriter w = new StreamWriter(s))
    w.Write($"{listOfNecklaces}\nTotal price Box of necklaces: {listOfNecklaces.TotalNecklaceBoxPrice():C2}" +
        $"\nTotal amount of black pearls: {listOfNecklaces.TotalNumberOfBlackPearls()}");

Console.WriteLine(new FileInfo(bname("BoxOfNecklaces_uncompressed.text")).Length);

using (Stream s = File.Create(bname("BoxOfNecklaces_compressed.zip")))
using (Stream ds = new GZipStream(s, CompressionMode.Compress))
using (TextWriter w = new StreamWriter(ds))
    w.Write($"{listOfNecklaces}\nTotal price Box of necklaces: {listOfNecklaces.TotalNecklaceBoxPrice():C2}" +
        $"\nTotal amount of black pearls: {listOfNecklaces.TotalNumberOfBlackPearls()}");

Console.WriteLine(new FileInfo(bname("BoxOfNecklaces_compressed.zip")).Length);



static string bname(string name)
{
    var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    documentPath = Path.Combine(documentPath, "MyProjects", "Exercises");
    if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
    return Path.Combine(documentPath, name);
}
var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

string startPath = Path.Combine(documentPath, "MyProjects", "Exercises");
string zipFile = Path.Combine(documentPath, "MyProjects", "Exercises.zip");
string extractPath = Path.Combine(documentPath, "MyProjects", "Extract");

if (File.Exists(zipFile)) File.Delete(zipFile);
ZipFile.CreateFromDirectory(startPath, zipFile);
Console.WriteLine();
Console.WriteLine($"Zip Created: {zipFile}");

if (Directory.Exists(extractPath)) Directory.Delete(extractPath, true);
ZipFile.ExtractToDirectory(zipFile, extractPath);
Console.WriteLine($"Zip Extracted: {extractPath}");

using (ZipArchive archive = ZipFile.OpenRead(zipFile))
{
    foreach (ZipArchiveEntry entry in archive.Entries)
    {
        Console.WriteLine(entry.FullName);
    }
}

static void OpenFolder(string folderPath)
{
    if (Directory.Exists(folderPath))
    {
        ProcessStartInfo startInfo = new ProcessStartInfo()
        {
            Arguments = folderPath,
            FileName = "explorer.exe"
        };

        Process.Start(startInfo);
    }
}

//OpenFolder(startPath);