using BlazorDemo.Data.Models;
using BlazorDemo.Data;
using BlazorServerDemo2024.Core.DTO;
using BlazorServerDemo2024.Core;
using Microsoft.EntityFrameworkCore;
using BlazorServerDemo2024.Services;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

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

app.UseCors(MyAllowSpecificOrigins);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var categoriesGroup = app.MapGroup("/categories");

categoriesGroup.MapGet("/", async (
    IGenericData<Category, CategoriaDTO, CreaCategoriaDTO, int>
    categoriesService) => {
    return Results.Ok(await categoriesService.EstraiItemsAsync());
});

categoriesGroup.MapGet("/{id}", async (int id, IGenericData<Category, CategoriaDTO, CreaCategoriaDTO, int>
    categoriesService) => { 
    var category = await categoriesService.EstraiItemPerId(id);
    return category is not null ? Results.Ok(category) : Results.NotFound();
});


categoriesGroup.MapPost("/", async (CreaCategoriaDTO newCategory,
    IGenericData<Category, CategoriaDTO, CreaCategoriaDTO, int>
    categoriesService) =>
{
    if(newCategory is null) return Results.BadRequest();
    if(string.IsNullOrEmpty(newCategory.Nome)) 
        return Results.BadRequest("Manca il nome della categoria");
    if (string.IsNullOrEmpty(newCategory.Descrizione))
        return Results.BadRequest("Manca la descrizione della categoria");
    if(newCategory.Nome.Length > 15)
        return Results.BadRequest("Il nome della categoria è troppo lungo (max 15 caratteri)");

    var id = await categoriesService.AggiungiItem(newCategory);
    var categoriaDTO = new CategoriaDTO { Id = id, 
        Nome = newCategory.Nome, Descrizione = newCategory.Descrizione };
    return Results.Created($"/categories/{id}", categoriaDTO);
});

categoriesGroup.MapPut("/{id}", async (int id, CategoriaDTO categoriaModificata,
    IGenericData<Category, CategoriaDTO, CreaCategoriaDTO, int>
    categoriesService) => {

        if (categoriaModificata is null) return Results.BadRequest();
        if (categoriaModificata.Id != id) return Results.BadRequest("Id non corrispondente");

        var categoriaDb = await categoriesService.EstraiItemPerId(id);
        if(categoriaDb is null) return Results.NotFound();
        await categoriesService.ModificaItem(categoriaModificata);
        return Results.NoContent();
    });

categoriesGroup.MapPatch("/{id}", async (int id, CategoriaDTO categoriaModificata,
    IGenericData<Category, CategoriaDTO, CreaCategoriaDTO, int>
    categoriesService) => {

        if (categoriaModificata is null) return Results.BadRequest();
        if (categoriaModificata.Id != id) return Results.BadRequest("Id non corrispondente");

        var categoriaDb = await categoriesService.EstraiItemPerId(id);
        if (categoriaDb is null) return Results.NotFound();

        if(!string.IsNullOrEmpty(categoriaModificata.Nome))
        {
            categoriaDb.Nome = categoriaModificata.Nome;
        }

        if (!string.IsNullOrEmpty(categoriaModificata.Descrizione))
        {
            categoriaDb.Descrizione = categoriaModificata.Descrizione;
        }

        await categoriesService.ModificaItem(categoriaDb);
        return Results.NoContent();
    });

categoriesGroup.MapDelete("/{id}", async (int id, 
    IGenericData<Category, CategoriaDTO, CreaCategoriaDTO, int>
    categoriesService) => {
        var categoriaDb = await categoriesService.EstraiItemPerId(id);
        if (categoriaDb is null) return Results.NotFound();
        await categoriesService.EliminaItem(id);
        return Results.NoContent();
    });



app.Run();

