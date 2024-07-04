using BlazorDemo.Data.Models;
using BlazorDemo.WebAssembly;
using BlazorDemo.WebAssembly.Services;
using BlazorDemoComponentsLibrary;
using BlazorDemoWebAssembly.Services;
using BlazorServerDemo2024.Core;
using BlazorServerDemo2024.Core.DTO;
using BlazorServerDemo2024.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("myapi", client => client.BaseAddress = new Uri("https://localhost:7218"));

builder.Services.AddScoped<IEventi, ServizioWebAssemblyEventi>();
builder.Services.AddScoped<IPersona, ServizioPersoneWebAssembly>();

builder.Services.AddScoped<IGenericData<Category,
     CategoriaDTO, CreaCategoriaDTO, int>, ServizioCategorie>();
//builder.Services.AddScoped<IGenericData<Customer,
//     ClienteDTO, ClienteDTO, string>, GenericCustomersDataService>();

await builder.Build().RunAsync();
