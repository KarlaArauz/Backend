using Enee.Core.CQRS.Query;
using xyz.Domain.Personas.Events;

namespace xyz.Domain.Personas.Projections.Projectors;

public class PersonaTableProjector:TableProjector<PersonaTabla>,IProjectorAsync
{



    public PersonaTableProjector()
    {
        Create<PersonaCreada>((evento, tablaPersona) =>
        {
            tablaPersona.Id = evento.AggregateId;
            tablaPersona.Nombre = evento.Nombre;
            tablaPersona.Version = 1;


        });

        Project<NombreEditado>((editado, view) =>
        {
            view.Nombre = editado.Nombre;

        });

        Deleted<PersonaEliminada>();
    }
}
