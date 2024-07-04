using BlazorDemo.Data.Models;
using BlazorServerDemo2024.Core;
using BlazorServerDemo2024.Core.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorServerDemo2024.Services;

public class GenericCategoriesDataService
    : IGenericData<Category, CategoriaDTO, CreaCategoriaDTO, int>
{
    private readonly IRepository<Category, int> repository;

    public GenericCategoriesDataService(
        IRepository<Category, int> repository)
    {
        this.repository = repository;
    }

    public async Task<int> AggiungiItem(CreaCategoriaDTO createDTO)
    {
       var newItem =  new Category
        {
            CategoryName = createDTO.Nome,
            Description = createDTO.Descrizione
        };
        return await repository.AddAsync(newItem);
    }

    public async Task EliminaItem(int id)
    {
        await repository.DeleteAsync(id);
    }

    public async Task<CategoriaDTO?> EstraiItemPerId(int id)
    {
        var category = await repository.GetByIdAsync(id);
        return category == null ? null : new CategoriaDTO
        {
            Id = category.Id,
            Nome = category.CategoryName,
            Descrizione = category.Description
        };
    }

    public async Task<IEnumerable<CategoriaDTO>?> EstraiItemsAsync()
    {
        return await repository.GetAll()
            .Include(c => c.Products)
            .Select(c => new CategoriaDTO
            {
                 Descrizione = c.Description,
                 Id = c.Id,
                 Nome = c.CategoryName,
                 NumeroProdotti = c.Products.Count
            }).ToListAsync();
            
    }

    public async Task<IEnumerable<CategoriaDTO>?> FilterAsync(Expression<Func<Category, bool>> filter)
    {
        return  (await repository.GetAllAsync(filter))
            .Select( c => new CategoriaDTO { 
             Descrizione = c.Description,
             Id = c.Id,
             Nome = c.CategoryName
            });
    }

    public async Task ModificaItem(CategoriaDTO dto)
    {
        await repository.UpdateAsync(new Category
        {
            Id = dto.Id,
            CategoryName = dto.Nome,
            Description = dto.Descrizione
        });
    }
}
