using Enee.Core.Events;

namespace xyz.Domain.Parametros.Events.CatalogoCreado;

public class EnviarCorreoElectronico:IEventHandler<CrearCatalogo.CatalogoCreado>
{
    public async Task Handle(CrearCatalogo.CatalogoCreado @event)
    {
        Console.WriteLine("Ejemplo de envio de correo");
    }
}