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
var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + Path.DirectorySeparatorChar;
var lifeFilename = "life.json";
var ccPublicationsFilename = "cc-publications.json";

// --
// -- Please do not change the code below
// --

Console.WriteLine($"""
#################
#    Life.NET   #
# - Generator - #
#################

The following files will be generated for '{life.Persona.GetFullname()}'
at location: '{desktopPath}':

""");

// 1. Ask the user if he wants to create a life file
Console.WriteLine($"Create '{lifeFilename}'? y/n");
Console.Write("> ");
if (Console.ReadLine() == "y")
{
    string path = desktopPath + lifeFilename;
    File.WriteAllText(path, Exporter.ExportLife(life));
}

// 2. Ask the user if he wants to create a publications file
Console.WriteLine($"\nCreate '{ccPublicationsFilename}'? y/n");
Console.Write("> ");
if (Console.ReadLine() == "y")
{
    string path = desktopPath + ccPublicationsFilename;
    File.WriteAllText(path, await Exporter.ExportPublicationsAsync(life.ContentCreation));
}

// 3. Print finished message
Console.WriteLine("\n\nFinished\n\n");