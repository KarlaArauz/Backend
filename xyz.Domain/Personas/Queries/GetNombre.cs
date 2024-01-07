using Enee.Core.CQRS.Query;

namespace xyz.Domain.Personas.Queries;

public record GetNombre:IQuery<string>
{
    public string Nombre { get; set; }
    public string Description { get; }
}