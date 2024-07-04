using BlazorServerDemo2024.Core.DTO;

namespace BlazorDemo.Data.Interfaces;

public interface ICategoriesData
{
    //Task<IEnumerable<Category>> GetCategoriesAsync();
    //IQueryable<Category> GetCategories();

    Task<IEnumerable<CategoriaDTO>?> EstraiCategorieAsync();
    IQueryable<CategoriaDTO>? EstraiCategorie();
    Task<int> AggiungiCategoria(CreaCategoriaDTO nuovaCategoria);
    Task EliminaCategoria(int id);  
    Task ModificaCategoria(CategoriaDTO categoria);
}
 