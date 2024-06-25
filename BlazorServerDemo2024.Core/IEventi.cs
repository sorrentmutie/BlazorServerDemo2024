namespace BlazorServerDemo2024.Core;

public interface IEventi
{
    IEnumerable<Evento> EstraiEventiFuturi();
    IEnumerable<Evento> EstraiEventiPassati();
}
