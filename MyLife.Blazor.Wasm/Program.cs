using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyLife.Blazor.Wasm;
using MyLife.Core.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

Console.WriteLine(builder.HostEnvironment.BaseAddress);
var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var lifeService = new LifeService(httpClient);
var mediumService = new MediumService(httpClient);

builder.Services.AddScoped(sp => httpClient);
builder.Services.AddSingleton(lifeService);
builder.Services.AddSingleton(mediumService);

await builder.Build().RunAsync();