
namespace MyLife.Core.Models.External;


public record KotlogFeedModel(DateTimeOffset LastUpdated , string Url, KotlogItemModel[] Items);