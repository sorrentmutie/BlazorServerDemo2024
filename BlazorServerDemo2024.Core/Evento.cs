namespace BlazorServerDemo2024.Core;

public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Descrizione { get; set; } = string.Empty;
    public string Località { get; set; } = string.Empty;
}
