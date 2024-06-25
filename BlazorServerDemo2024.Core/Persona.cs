using System.ComponentModel.DataAnnotations;

namespace BlazorServerDemo2024.Core;

public class Persona
{
    public  int Id { get; set; }
    [Required (ErrorMessage = "Nome obbligatorio")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "Cognome obbligatorio")]
    public string? Cognome { get; set; }
}
