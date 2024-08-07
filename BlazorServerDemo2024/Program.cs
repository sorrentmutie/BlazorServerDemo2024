using BlazorDemo.Data;
using BlazorDemo.Data.Interfaces;
using BlazorDemo.Data.Models;
using BlazorServerDemo2024.Core;
using BlazorServerDemo2024.Core.DTO;
using BlazorServerDemo2024.Data;
using BlazorServerDemo2024.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IEventi, ServizioStaticoEventi>();
builder.Services.AddScoped<IPersona, ServizioStaticoPersone>();
builder.Services.AddDbContext<NorthwindContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind")));

builder.Services.AddScoped<IRepository<Category, int>,
    GenericRepository<Category, int>>();
builder.Services.AddScoped<IRepository<Customer, string>,
    GenericRepository<Customer, string>>();

builder.Services.AddScoped<DbContext, NorthwindContext>();

builder.Services.AddScoped<IGenericData<Category,
     CategoriaDTO, CreaCategoriaDTO, int>, GenericCategoriesDataService>();
builder.Services.AddScoped<IGenericData<Customer,
     ClienteDTO, ClienteDTO, string>, GenericCustomersDataService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
