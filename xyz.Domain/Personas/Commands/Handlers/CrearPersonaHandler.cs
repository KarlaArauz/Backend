using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace xyz.Domain.Personas.Commands.Handlers;

public class CrearPersonaHandler:ICommandHandler<CrearPersona>
{
    public IWritableEventStoreRepository<Persona> Repository { get; }

    public CrearPersonaHandler(IWritableEventStoreRepository<Persona> repository)
    {
        Repository = repository;
    }
    public  async Task Handle(CrearPersona command)
    {
        await Repository.Create(new Persona(command.Id, command.Nombre, command.Apellido));
        
    }
}