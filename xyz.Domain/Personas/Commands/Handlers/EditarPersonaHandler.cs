using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace xyz.Domain.Personas.Commands.Handlers;

public class EditarPersonaHandler:ICommandHandler<EditarPersona>
{
    public IWritableEventStoreRepository<Persona> Repository { get; }

    public EditarPersonaHandler(IWritableEventStoreRepository<Persona> repository)
    {
        Repository = repository;
    }
    public  async Task Handle(EditarPersona command)
    {
        var persona = await Repository.Find(command.Id);
        persona.CorregirNombre(command.Nombre);
        await Repository.Update(persona);
        
    }
}