using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerDemo2024.Core;

public interface IPersona
{
    IEnumerable<Persona> EstraiPersone();
    Persona EstraiPersona(int id);
    void AggiungiPersona(Persona persona);
    void ModificaPersona(Persona persona);
    void EliminaPersona(int id);
}
