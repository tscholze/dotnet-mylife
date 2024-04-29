using MyLife.Core.Generator;
using Newtonsoft.Json;

namespace MyLife.Core;

public static class Exporter
{
    public static string ExportLife() {
        return JsonConvert.SerializeObject(SampleGenerators.GenerateLife());
    }
}
