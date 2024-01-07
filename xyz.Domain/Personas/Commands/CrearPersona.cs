using Enee.Core.CQRS.Command;

namespace xyz.Domain.Personas.Commands;

public record CrearPersona(Guid Id, string Nombre, string Apellido):ICommand;