using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerDemo2024.Core.DTO;

public class CategoriaDTO
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descrizione { get; set; } = string.Empty;

    public int NumeroProdotti { get; set; }

}

public class CreaCategoriaDTO
{
    [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
    [StringLength(15, ErrorMessage = "Il campo Nome deve essere lungo al massimo {1} caratteri")]
    public string Nome { get; set; } = string.Empty;

    public string Descrizione { get; set; } = string.Empty;
}
