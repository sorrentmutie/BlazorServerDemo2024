using BlazorServerDemo2024.Core;

namespace BlazorServerDemo2024.Services;

public class ServizioStaticoPersone : IPersona
{
    public static List<Persona> persone =
        new List<Persona>
        {
     new Persona { Id = 1, Nome = "Mario", Cognome = "Rossi" },
            new Persona { Id = 2, Nome = "Luigi", Cognome = "Verdi" },
            new Persona { Id = 3, Nome = "Paolo", Cognome = "Bianchi" }
        };

    public void AggiungiPersona(Persona persona)
    {
        persona.Id = persone.Max(p => p.Id) + 1;
        persone.Add(persona);
    }

    public void EliminaPersona(int id)
    {
        throw new NotImplementedException();
    }

    public Persona EstraiPersona(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Persona> EstraiPersone()
    {
        return persone;
    }

    public void ModificaPersona(Persona persona)
    {
        var personaDb = persone.FirstOrDefault(p => p.Id == persona.Id);
        if(personaDb != null)
        {
            personaDb.Nome = persona.Nome;
            personaDb.Cognome = persona.Cognome;
        }

    }
}
