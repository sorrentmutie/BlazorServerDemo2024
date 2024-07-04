using BlazorDemo.Data.Models;
using BlazorServerDemo2024.Core.DTO;
using BlazorServerDemo2024.Core;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace BlazorDemo.WebAssembly.Services;

public class ServizioCategorie : IGenericData<Category,
     CategoriaDTO, CreaCategoriaDTO, int>
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly IConfiguration configuration;
    //private string? BaseUrl => configuration["UrlApiCategorie"];

    public ServizioCategorie(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        this.httpClientFactory = httpClientFactory;
        this.configuration = configuration;
    }

    public async Task<int> AggiungiItem(CreaCategoriaDTO createDTO)
    {
        var httpClient = httpClientFactory.CreateClient("myapi");
        var response = await httpClient.PostAsJsonAsync("/categories", createDTO);
        var content = await response.Content.ReadFromJsonAsync<CategoriaDTO>();
        return content?.Id ?? 0;
    }

    public async Task EliminaItem(int id)
    {
        var httpClient = httpClientFactory.CreateClient("myapi");
        await httpClient.DeleteAsync($"/categories/{id}");
    }

    public Task<CategoriaDTO?> EstraiItemPerId(int id)
    {
        var httpClient = httpClientFactory.CreateClient("myapi");
        return httpClient.GetFromJsonAsync<CategoriaDTO>($"/categories/{id}");
    }

    public async Task<IEnumerable<CategoriaDTO>?> EstraiItemsAsync()
    {
        var httpClient = httpClientFactory.CreateClient("myapi");

        var response = await httpClient.GetAsync("/categories");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content
                .ReadFromJsonAsync<IEnumerable<CategoriaDTO>>();
        } else
        {
            return null;
        }
    }

    public Task<IEnumerable<CategoriaDTO>?> FilterAsync(Expression<Func<Category, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task ModificaItem(CategoriaDTO dto)
    {
        var httpClient = httpClientFactory.CreateClient("myapi");
        await httpClient.PutAsJsonAsync($"/categories/{dto.Id}", dto);
    }
}
