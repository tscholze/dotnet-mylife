using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyLife.Blazor.Wasm;
using MyLife.Core.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configure root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure services
ConfigureServices(builder.Services, builder);

await builder.Build().RunAsync();

static void ConfigureServices(IServiceCollection services, WebAssemblyHostBuilder builder)
{
    // Configure HttpClient
    var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
    services.AddScoped(sp => httpClient);

    // Configure application services
    services.AddSingleton<LifeService>(sp => new LifeService(httpClient));
    services.AddSingleton<MediumService>(sp => new MediumService(httpClient));

    // Add logging in development
    if (builder.HostEnvironment.IsDevelopment())
    {
        services.AddLogging();
    }
}