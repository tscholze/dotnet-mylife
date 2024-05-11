using MyLife.Core;
using MyLife.Core.Extensions;
using MyLife.Core.Generator;

// --
// -- Change code
// --

/* Create your own life
var life = new Life
{
    Persona = ...,
    ContentCreation = ...,
    Container = ...
}
*/

// ... or use a sample
var life = SampleGenerators.GenerateLife();

// --
// -- Please do not change the code below
// --

Console.WriteLine($"""
#############
# life.json #
#############

Create json for life of '{life.Persona.GetFullname()}'? y/n
""".Trim());
Console.Write("> ");

if (Console.ReadLine() == "y")
{
    Console.WriteLine("\n\nSave life.json to Desktop? (y/n) ");
    Console.Write("> ");
    if (Console.Read() == 'y')
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "life.json";
        File.WriteAllText(path, Exporter.ExportLife(life));
        Console.WriteLine($"\nCreate file at: {path}");
    }
}
else
{
    Console.WriteLine("\nAborted. Exit\n\n");
}