using MyLife.Core.Models;
using Newtonsoft.Json;

namespace MyLife.Core;

/// <summary>
/// Life exporter.
/// </summary>
public static class Exporter
{
    /// <summary>
    /// Export a life to a JSON string.
    /// </summary>
    /// <param name="life">Life to convert</param>
    /// <returns>Resulting JSON string</returns>
    public static string ExportLife(Life life) {
        return JsonConvert.SerializeObject(life);
    }
}
