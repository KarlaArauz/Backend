using Enee.Core.CQRS.Query;
using xyz.Domain.Personas.Events;

namespace xyz.Domain.Personas.Projections.Projectors;

public class PersonaDocumentProjector:DocumentProjector<PersonaDocumento>
{



    public PersonaDocumentProjector()
    {


        Project<PersonaCreada>((e, view) =>
        {
            view.Id = e.AggregateId;
            view.Nombre = e.Nombre;
            view.Apellido = e.Apellido;
        });

        Project<NombreEditado>((editado, view) =>
        {
            view.Nombre = editado.Nombre;

        });


    }


}
