using Enee.Core.Common;
using Enee.Core.CQRS.Query;

namespace xyz.Domain.Personas.Projections;


[DocumentName("persona_documento")]
public class PersonaDocumento:IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
}