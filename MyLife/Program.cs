using MyLife.Core;
using MyLife.Core.Extensions;
using MyLife.Core.Generator;

#region User-changeable code

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

#endregion

#region Constants

const string lifeFilename = "life.json";
const string ccPublicationsFilename = "cc-publications.json";
var absoluteDesktopPath = string.Join(Path.DirectorySeparatorChar, [Environment.GetFolderPath(Environment.SpecialFolder.Desktop)]);
var relativeWwwRootPath = string.Join(Path.DirectorySeparatorChar, ["..", "..", "..", "..", Constants.MyLifeBlazorWasmLocalPath, "wwwroot", "data"]);

#endregion

#region CLI

Console.WriteLine($"""
#################
#    Life.NET   #
# - Generator - #
#################

The following files will be generated for '{life.Persona.GetFullname()}'
at location: '{absoluteDesktopPath}' and / or in `wwwroot` folders:

""");

// 1. Ask the user if he wants to create a life file
Console.WriteLine($"Create '{lifeFilename}'? y/n");
Console.Write("> ");
if (Console.ReadLine() == "y")
{
    // 1.1. Export life to json
    var json = Exporter.ExportLife(life);
    var path = string.Join(Path.DirectorySeparatorChar, [absoluteDesktopPath, lifeFilename]);
    File.WriteAllText(path, json);

    // 1.2. Ask the user if he wants to update wwwroot files
    Console.WriteLine($"\nUpdate 'wwwroot' file?");
    Console.Write("> ");
    if (Console.ReadLine() == "y")
    {
        var wwwPath = string.Join(Path.DirectorySeparatorChar, [relativeWwwRootPath, lifeFilename]);
        File.WriteAllText(wwwPath, json);
    }
}

// 2. Ask the user if he wants to create a publications file
Console.WriteLine($"\nCreate '{ccPublicationsFilename}'? y/n");
Console.Write("> ");
if (Console.ReadLine() == "y")
{
    // 2.1. Export content creation publications to json
    var json = await Exporter.ExportPublicationsAsync(life.ContentCreation);
    var path = string.Join(Path.DirectorySeparatorChar, [absoluteDesktopPath, ccPublicationsFilename]);
    File.WriteAllText(path, json);

    // 2.2. Ask the user if he wants to update wwwroot files
    Console.WriteLine($"\nUpdate 'wwwroot' file?");
    Console.Write("> ");
    if (Console.ReadLine() == "y")
    {
        var wwwPath = string.Join(Path.DirectorySeparatorChar, [relativeWwwRootPath, ccPublicationsFilename]);
        File.WriteAllText(wwwPath, json);
    }
}

// 3. Print finished message
Console.WriteLine("\n\nFinished\n\n");

#endregion