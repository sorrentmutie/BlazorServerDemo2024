using BlazorDemo.Data.Interfaces;
using BlazorDemo.Data.Models;
using BlazorServerDemo2024.Core.DTO;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerDemo2024.Services;

public class CategoriesDataSQLServer : ICategoriesData
{
    private readonly NorthwindContext northwindContext;

    public CategoriesDataSQLServer(NorthwindContext northwindContext)
    {
        this.northwindContext = northwindContext;
    }

    public async Task<int> AggiungiCategoria(CreaCategoriaDTO nuovaCategoria)
    {
        var category = new Category
        {
            CategoryName = nuovaCategoria.Nome,
            Description = nuovaCategoria.Descrizione
        };
        northwindContext.Categories.Add(category);
        await northwindContext.SaveChangesAsync();
        return category.Id;
    }

    public async Task EliminaCategoria(int id)
    {
        var category = await northwindContext.Categories.FindAsync(id);
        if (category != null)
        {
            northwindContext.Categories.Remove(category);
            await northwindContext.SaveChangesAsync();
        }
    }

    public IQueryable<CategoriaDTO>? EstraiCategorie()
    {
        return northwindContext.Categories.Select(c => new CategoriaDTO
        {
            Id = c.Id,
            Nome = c.CategoryName,
            Descrizione = c.Description
        });
    }

    public async Task<IEnumerable<CategoriaDTO>?> EstraiCategorieAsync()
    {
        return  await northwindContext.Categories
            .Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Nome = c.CategoryName,
                Descrizione = c.Description,
                NumeroProdotti = c.Products.Count
            })
            .ToListAsync();
    }

    public async Task ModificaCategoria(CategoriaDTO categoria)
    {
        var categoriaDb = await northwindContext.Categories.FindAsync(categoria.Id);
        if(categoriaDb != null)
        {
            categoriaDb.CategoryName = categoria.Nome;
            categoriaDb.Description = categoria.Descrizione;
            await northwindContext.SaveChangesAsync();
        }
    }

    //public IQueryable<Category> GetCategories()
    //{
    //   return northwindContext.Categories;
    //}

    //public async Task<IEnumerable<Category>> GetCategoriesAsync()
    //{
    //    return await northwindContext.Categories.ToListAsync();
    //}
}
