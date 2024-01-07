using Enee.Core.Common;

namespace xyz.Domain.Personas.Projections;

public class PersonaTabla:IEntity<Guid>
{

    public  Guid Id { get; set; }


    public string Nombre { get; set; }
    public long Version { get; set; }
    
    
}