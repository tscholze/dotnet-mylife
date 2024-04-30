using MyLife.Core.Generator;
using MyLife.Core.Models;
using Newtonsoft.Json;

namespace MyLife.Core;

/// <summary>
/// Life exporter.
/// </summary>
public static class Exporter
{
    public static string ExportLife(Life life) {
        return JsonConvert.SerializeObject(life);
    }
}
