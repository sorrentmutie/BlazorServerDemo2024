using BlazorServerDemo2024.Core;

namespace BlazorDemoWebAssembly.Services;

public class ServizioWebAssemblyEventi : IEventi
{
    public void AggiungiEventoPassato(Evento evento)
    {
        throw new NotImplementedException();
    }

    public void EliminaEventoPassato(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Evento> EstraiEventiFuturi()
    {
        return new List<Evento>
        {
            new Evento
            {
                Data = new DateTime(2024, 1, 1),
                Nome = "Capodanno 2024",
                Descrizione = "Festeggiamenti per l'arrivo del nuovo anno",
                Località = "Terra"
            },
            new Evento
            {
                Data = new DateTime(2024, 12, 25),
                Nome = "Natale 2024",
                Descrizione = "Festeggiamenti per il Natale",
                Località = "Terra"
            }
        };
    }

    public IEnumerable<Evento> EstraiEventiPassati()
    {
        throw new NotImplementedException();
    }

    public void ModificaEventoPassato(Evento evento)
    {
        throw new NotImplementedException();
    }
}
