using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace xyz.Domain.Parametros.CrearCatalogo;

public class CrearCatalogoHandler:ICommandHandler<CrearCatalogoCommand>
{
    public IWritableRepository<Catalogo> Catalogo { get; }

    public CrearCatalogoHandler(IWritableRepository<Catalogo> catalogo)
    {
        Catalogo = catalogo;
    }
    public async Task Handle(CrearCatalogoCommand command)
    {
        var entity = new Catalogo(command.Id, command.Nombre);
        await Catalogo.Create(entity);
    }
}