using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerDemo2024.Core.DTO;

public class CategoriaDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descrizione { get; set; } = string.Empty;

}

public class CreaCategoriaDTO
{
    public string Nome { get; set; } = string.Empty;

    public string Descrizione { get; set; } = string.Empty;
}
