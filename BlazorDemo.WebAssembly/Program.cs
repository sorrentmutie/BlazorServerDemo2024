using BlazorDemo.WebAssembly;
using BlazorDemoComponentsLibrary;
using BlazorDemoWebAssembly.Services;
using BlazorServerDemo2024.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IEventi, ServizioWebAssemblyEventi>();
builder.Services.AddScoped<IPersona, ServizioPersoneWebAssembly>();

await builder.Build().RunAsync();
