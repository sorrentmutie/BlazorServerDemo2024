using BlazorServerDemo2024.Core;

namespace BlazorServerDemo2024.Services;

public class ServizioStaticoEventi : IEventi
{
    private static  List<Evento> eventiPassati = new List<Evento>()
        {   new Evento { Id = 1, Data = DateTime.Today.AddDays(-1), Descrizione = "Intro a Blazor", Località = "Napoli", Nome = "Lezione 1. Introduzione a Blazor" },
            new Evento { Id = 2, Data = DateTime.Today.AddDays(-1), Descrizione = "Blazor e Razor", Località = "Napoli", Nome = "Lezione 2. Blazor e Razor" },
            new Evento { Id = 3, Data = DateTime.Today.AddDays(-2), Descrizione = "Componenti e Routing", Località = "Napoli", Nome = "Lezione 3. Componenti e Routing" },
            new Evento { Id = 4, Data = DateTime.Today.AddDays(-3), Descrizione = "Gestione degli eventi", Località = "Napoli", Nome = "Lezione 4. Gestione degli eventi" },
            new Evento { Id = 5, Data = DateTime.Today.AddDays(-4), Descrizione = "Comunicazione tra componenti", Località = "Napoli", Nome = "Lezione 5. Comunicazione tra componenti" },
            new Evento { Id = 6, Data = DateTime.Today.AddDays(-5), Descrizione = "Autenticazione e autorizzazione", Località = "Napoli", Nome = "Lezione 6. Autenticazione e autorizzazione" },
            new Evento { Id = 7, Data = DateTime.Today.AddDays(-6), Descrizione = "Blazor Server e Blazor WebAssembly", Località = "Napoli", Nome = "Lezione 7. Blazor Server e Blazor WebAssembly" },
            new Evento { Id = 8, Data = DateTime.Today.AddDays(-7), Descrizione = "Blazor e ASP.NET Core", Località = "Napoli", Nome = "Lezione 8. Blazor e ASP.NET Core" }
        };

public void AggiungiEventoPassato(Evento evento)
    {
        var id =  eventiPassati.Count() > 0 ? eventiPassati.Max(e => e.Id) + 1 : 1;
        evento.Id = id;
        eventiPassati.Add(evento);
    }

    public void EliminaEventoPassato(int id)
    {
        var eventoDb = eventiPassati.FirstOrDefault(e => e.Id == id);
        if(eventoDb != null)
        {
            eventiPassati.Remove(eventoDb);
        }
    }

    public IEnumerable<Evento> EstraiEventiFuturi()
    {
        return new List<Evento>()
        {   new Evento { Id = 1, Data = DateTime.Today, Descrizione = "Intro a Blazor", Località = "Napoli", Nome = "Lezione 1. Introduzione a Blazor" },
            new Evento { Id = 2, Data = DateTime.Today.AddDays(1), Descrizione = "Blazor e Razor", Località = "Napoli", Nome = "Lezione 2. Blazor e Razor" },
            new Evento { Id = 3, Data = DateTime.Today.AddDays(2), Descrizione = "Componenti e Routing", Località = "Napoli", Nome = "Lezione 3. Componenti e Routing" },
            new Evento { Id = 4, Data = DateTime.Today.AddDays(3), Descrizione = "Gestione degli eventi", Località = "Napoli", Nome = "Lezione 4. Gestione degli eventi" },
            new Evento { Id = 5, Data = DateTime.Today.AddDays(4), Descrizione = "Comunicazione tra componenti", Località = "Napoli", Nome = "Lezione 5. Comunicazione tra componenti" },
            new Evento { Id = 6, Data = DateTime.Today.AddDays(5), Descrizione = "Autenticazione e autorizzazione", Località = "Napoli", Nome = "Lezione 6. Autenticazione e autorizzazione" },
            new Evento { Id = 7, Data = DateTime.Today.AddDays(6), Descrizione = "Blazor Server e Blazor WebAssembly", Località = "Napoli", Nome = "Lezione 7. Blazor Server e Blazor WebAssembly" },
            new Evento { Id = 8, Data = DateTime.Today.AddDays(7), Descrizione = "Blazor e ASP.NET Core", Località = "Napoli", Nome = "Lezione 8. Blazor e ASP.NET Core" }
        };
    }
  

    public IEnumerable<Evento> EstraiEventiPassati()
    {
        return eventiPassati;
    }

    public void ModificaEventoPassato(Evento evento)
    {
        var eventoDb = eventiPassati.FirstOrDefault(e => e.Id == evento.Id);   
        if(eventoDb != null)
        {
            eventoDb.Nome = evento.Nome;
            eventoDb.Descrizione = evento.Descrizione;
            eventoDb.Località = evento.Località;
            eventoDb.Data = evento.Data;
        }
    }
}
