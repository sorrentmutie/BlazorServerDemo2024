using BlazorDemo.Data.Models;
using BlazorServerDemo2024.Core;
using BlazorServerDemo2024.Core.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorServerDemo2024.Services
{
    public class GenericCustomersDataService
        : IGenericData<Customer, ClienteDTO, ClienteDTO, string>
    {
        private readonly IRepository<Customer, string> repository;

        public GenericCustomersDataService(
            IRepository<Customer, string> repository)
        {
            this.repository = repository;
        }

        public Task<string> AggiungiItem(ClienteDTO createDTO)
        {
            throw new NotImplementedException();
        }

        public Task EliminaItem(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO?> EstraiItemPerId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ClienteDTO>?> EstraiItemsAsync()
        {
           return await repository.GetAll()
                .Select(c => new ClienteDTO
                {
                    Codice = c.Id,
                    Nome = c.CompanyName,
                    IndirizzoCompleto = $"{c.Address} {c.City} {c.PostalCode}"                 
                })
                .ToListAsync();
        }

        public Task<IEnumerable<ClienteDTO>?> FilterAsync(Expression<Func<Customer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task ModificaItem(ClienteDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
