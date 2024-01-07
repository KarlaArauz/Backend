using Enee.Core.Domain.Repository;
using Enee.Core.Events;
using xyz.Domain.Parametros;

namespace xyz.Domain.Personas.Events.Handlers;

// public class Saludar2EventHandler : IEventHandler<PersonaCreada>
// {
//     public Task Handle(PersonaCreada @event)
//     {
//         throw new NotImplementedException();
//     }
// }

public class CatalogoEventHandler:IEventHandler<PersonaCreada>
{
    public IWritableRepository<Catalogo> Catalogos { get; }

    public CatalogoEventHandler(IWritableRepository<Parametros.Catalogo> catalogos)
    {
        Catalogos = catalogos;
    }
    public async Task Handle(PersonaCreada @event)
    {
        Console.WriteLine("Paso por CatalogoEventHandler "+ @event.Nombre);
        await Catalogos.Create(new Catalogo(Guid.NewGuid(), @event.Nombre));
    
    }
    //
    // public void dd()
    // {
    //     var items = new SaludarEventHandler();
    //     var lista1 = new List<SaludarEventHandler>();
    //     var lista2 = new List<Saludar2EventHandler>();
    //     
    //     var lista = new List<IEventHandler<PersonaCreada>>();
    //     lista.AddRange(lista1);
    //     lista.AddRange(lista2);
    // }
}