using System.ComponentModel.DataAnnotations;

namespace BlazorServerDemo2024.Core;

public class Evento
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Il nome è obbligatorio")]
    [MinLength(3, ErrorMessage = "Il nome dell'evento deve superare i 3 caratteri")]
    [StringLength(50, ErrorMessage = "Il nome dell'evento non può superare i 50 caratteri.")]
    public string Nome { get; set; } = string.Empty;
    public DateTime Data { get; set; } = DateTime.Today;
    [Required(ErrorMessage = "La descrizione è obbligatoria")] 
    public string Descrizione { get; set; } = string.Empty;
    [Required(ErrorMessage = "La località è obbligatoria")]
    public string Località { get; set; } = string.Empty;
}
