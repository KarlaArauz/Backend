using Enee.Core.CQRS.Command;

namespace xyz.Domain.Parametros.CrearCatalogo;


public record CrearCatalogoCommand(Guid Id, string Nombre):ICommand;