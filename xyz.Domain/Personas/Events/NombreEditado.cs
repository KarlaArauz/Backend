using Enee.Core.Common;

namespace xyz.Domain.Personas.Events;

public class NombreEditado:DomainEvent<Guid>
{
    public string Description { get; set; }
    public string AggregateType { get; set; }
    public string AggregateName { get; set; }
   
    
    public string Nombre { get; set; }
    

    public NombreEditado(Guid aggregateId, string nombre) : base(aggregateId)
    {
        Nombre = nombre;
    }
    
}