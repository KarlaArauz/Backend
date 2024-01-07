using Enee.Core.Common;

namespace xyz.Domain.Personas.Events;

public class PersonaEliminada:DomainEvent<Guid>
{
    public DateTime FechaEliminacion { get; }

    public PersonaEliminada(Guid aggregateId,DateTime fechaEliminacion) : base(aggregateId)
    {
        FechaEliminacion = fechaEliminacion;
    }
}