using Enee.Core.CQRS.Command;

namespace xyz.Domain.Personas.Commands;

public class EditarPersona:ICommand
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
}