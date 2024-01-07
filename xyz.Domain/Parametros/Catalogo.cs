﻿using Enee.Core.Domain;
using xyz.Domain.Parametros.CrearCatalogo;

namespace xyz.Domain.Parametros;

public class Catalogo:AggregateRoot<Guid>
{
    public override Guid Id { get; set; }
    
    public string Nombre { get; set; }
    public Catalogo(Guid id, string nombre)
    {
        Apply(NewChange(new CatalogoCreado(id, nombre)));
    }

    
    private void Apply(CatalogoCreado @event)
    {
        Id = @event.AggregateId;
        Nombre = @event.Nombre;
        Version++;
    }
    
}