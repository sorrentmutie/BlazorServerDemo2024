using BlazorServerDemo2024.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerDemo2024.Core;

public interface IGenericData<TEntity, TDTO, TCreateDTO, TKey>
    where TEntity : class, IEntity<TKey>, new()
{

    Task<IEnumerable<TDTO>?> EstraiItemsAsync();
    Task<IEnumerable<TDTO>?> FilterAsync(Expression<Func<TEntity, bool>> filter);
    Task<TKey> AggiungiItem(TCreateDTO createDTO);
    Task EliminaItem(TKey id);
    Task ModificaItem(TDTO dto);
    Task<TDTO?> EstraiItemPerId(TKey id);

}
