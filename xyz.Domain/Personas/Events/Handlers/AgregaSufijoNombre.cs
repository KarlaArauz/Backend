using Enee.Core.Domain.Repository;
using Enee.Core.Events;

namespace xyz.Domain.Personas.Events.Handlers;

public class AgregaSufijoNombre:IEventHandler<PersonaCreada>
{
    public IWritableEventStoreRepository<Persona> Repository { get; }
    

    public AgregaSufijoNombre(IWritableEventStoreRepository<Persona> repository)
    {
        Repository = repository;
    
    }
    public async Task Handle(PersonaCreada @event)
    {
        var persona = new Persona();
        persona.Apply(@event);
        persona.CorregirNombre($"s_{@event.Nombre}");
        //var persona = await Repository.Find(@event.AggregateId);
        
        await Repository.Update(persona);

    }
    
}