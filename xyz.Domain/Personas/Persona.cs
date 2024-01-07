using Enee.Core.Domain;
using xyz.Domain.Personas.Events;

namespace xyz.Domain.Personas;

public class Persona:AggregateRoot<Guid>
{
    public override Guid Id { get; set; }

    public Persona()
    {
        
    }
    public string Nombre { get; set; }
    public string Apellido { get; set; }

    public Persona(Guid id, string nombre, string apellido)
    {
        Apply(NewChange(new PersonaCreada(id, nombre, apellido)));
    }
    public void CorregirNombre(string nombre)
    {
        Apply(NewChange(new NombreEditado(Id,nombre)));    
    }

    public void Borrar()
    {
        Apply(new PersonaEliminada(this.Id,DateTime.Now));
    }
    
    public void Apply(PersonaCreada @event)
    {
        Id = @event.AggregateId;
        Nombre = @event.Nombre;
        Apellido = @event.Apellido;
        Version++;
    }
    
    private void Apply(NombreEditado @event)
    {
        Id = @event.AggregateId;
        Nombre = @event.Nombre;
        Version++;
    }
    
    private void Apply(PersonaEliminada @event)
    {
        this.DeletedDate = @event.FechaEliminacion;
        Version++;
    }

    
    
}