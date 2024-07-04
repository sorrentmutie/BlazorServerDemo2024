using BlazorServerDemo2024.Core;

namespace BlazorDemoWebAssembly.Services
{
    public class ServizioPersoneWebAssembly : IPersona
    {
        public void AggiungiPersona(Persona persona)
        {
            throw new NotImplementedException();
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
            return new List<Persona>
            {
                new Persona { Id = 1, Nome = "Mario", Cognome = "Rossi" }
            };
        }

        public void ModificaPersona(Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}
