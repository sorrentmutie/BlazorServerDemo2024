namespace BlazorServerDemo2024.Core;

public interface IEventi
{
    IEnumerable<Evento> EstraiEventiFuturi();
    IEnumerable<Evento> EstraiEventiPassati();
    void AggiungiEventoPassato(Evento evento);
    void ModificaEventoPassato(Evento evento);
    void EliminaEventoPassato(int id);
}
