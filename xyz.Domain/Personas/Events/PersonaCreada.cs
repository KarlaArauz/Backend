using Enee.Core.Common;

namespace xyz.Domain.Personas.Events;

public class PersonaCreada:DomainEvent<Guid>
{
    public string Description { get; set; }
    public string AggregateType { get; set; }
    public string AggregateName { get; set; }

    
    
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    public PersonaCreada(Guid aggregateId, string nombre, string apellido) : base(aggregateId)
    {
        Nombre = nombre;
        Apellido = apellido;
    }
    
}