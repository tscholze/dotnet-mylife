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

// Check if the user or a CI/CD pipeline wants to run in silent mode
await (args.Contains("silent") ? PerformSilentAsync() : PerformInteractive());

#region CLI

/// <summary>
/// Performs export actions interactively.
/// </summary>
async Task PerformInteractive()
{
    // 1. Define paths
    var absoluteDesktopPath = string.Join(Path.DirectorySeparatorChar, [Environment.GetFolderPath(Environment.SpecialFolder.Desktop)]);

    // 2. Print welcome message
    Console.WriteLine($"""
        #################
        #    Life.NET   #
        # - Generator - #
        #################

        The following files will be generated for '{life.Persona.GetFullname()}'
        at location: '{absoluteDesktopPath}' and / or in `wwwroot` folders:

        """.Trim()
     );

    // 3. Ask the user if he wants to create a life file
    Console.WriteLine($"Create '{Constants.LifeJsonFilename}'? y/n");
    Console.Write("> ");
    if (Console.ReadLine() == "y")
    {
        // 3.1. Export life to json
        var json = Exporter.ExportLife(life);
        var path = string.Join(Path.DirectorySeparatorChar, [absoluteDesktopPath, Constants.LifeJsonFilename]);
        File.WriteAllText(path, json);

        // 3.2. Ask the user if he wants to update wwwroot files
        Console.WriteLine($"\nUpdate 'wwwroot' file?");
        Console.Write("> ");
        if (Console.ReadLine() == "y")
        {
            File.WriteAllText(GetReleativeWwwDataPath(Constants.LifeJsonFilename), json);
        }
    }

    // 4. Ask the user if he wants to create a publications file
    Console.WriteLine($"\nCreate '{Constants.ContentCreationPublicationsFilename}'? y/n");
    Console.Write("> ");
    if (Console.ReadLine() == "y")
    {
        // 4.1. Export content creation publications to json
        var json = await Exporter.ExportPublicationsAsync(life.ContentCreation);
        var path = string.Join(Path.DirectorySeparatorChar, [absoluteDesktopPath, Constants.ContentCreationPublicationsFilename]);
        File.WriteAllText(path, json);

        // 4.2. Ask the user if he wants to update wwwroot files
        Console.WriteLine($"\nUpdate 'wwwroot' file?");
        Console.Write("> ");
        if (Console.ReadLine() == "y")
        {
            File.WriteAllText(GetReleativeWwwDataPath(Constants.ContentCreationPublicationsFilename), json);
        }
    }

    // 5. Print finished message
    Console.WriteLine("\n\nFinished\n\n");

    #endregion
}

#region Action runner

async Task PerformSilentAsync()
{
    // 1. Export life to json
    File.WriteAllText(
        GetReleativeWwwDataPath(Constants.ContentCreationPublicationsFilename),
        Exporter.ExportLife(life)
    );

    // 2. Export content creation publications to json
    File.WriteAllText(
        GetReleativeWwwDataPath(Constants.ContentCreationPublicationsFilename),
        await Exporter.ExportPublicationsAsync(life.ContentCreation)
   );
}

#endregion

#region Helpers
string GetReleativeWwwDataPath(string filename)
{
    if (Directory.GetCurrentDirectory().Contains("Debug"))
    {
        return string.Join(Path.DirectorySeparatorChar, ["..", "..", "..", "..", Constants.MyLifeBlazorWasmLocalPath, "wwwroot", "data", filename]);
    }
    else
    {
        return string.Join(Path.DirectorySeparatorChar, ["..", Constants.MyLifeBlazorWasmLocalPath, "wwwroot", "data", filename]);
    }
}

#endregion