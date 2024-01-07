using xyz.Domain.Personas.Commands;
using xyz.Domain.Personas.Queries;
using Autofac.Features.AttributeFilters;
using xyz.Api.Controllers.Utils;
using Enee.Core.CQRS.Command;
using Enee.Core.CQRS.Query;
using xyz.Domain.Personas;
using Enee.IoC.Architecture;
using Enee.IoC.Architecture.Others;
using Microsoft.AspNetCore.Mvc;


namespace xyz.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonaController : ControllerBase
{
    public IDispatcher Dispatcher { get; }
    public IQueryDispatcher QueryDispatcher { get; }
    public IDispatcherFactory DispatcherFactory { get; }


    public PersonaController(IDispatcher dispatcher, IQueryDispatcher queryDispatcher)
    {
        Dispatcher = dispatcher;
        QueryDispatcher = queryDispatcher;
    }

    [HttpPost ]
    public async Task<IActionResult> Guardar([FromBody] CrearPersona request)
    {
        var id = Guid.NewGuid();
        var result = await Dispatcher.Dispatch(new CrearPersona(id,request.Nombre,request.Apellido));

       return result.ToResponse(new {Id=id});
    }

    [HttpPut("{id}") ]
    public async Task<IActionResult> Guardar([FromRoute] Guid id, [FromBody] EditarPersona editarPersona)
    {
        editarPersona.Id = id;
        var result = await Dispatcher.Dispatch(editarPersona);
        return result.ToResponse();
    }

    [HttpGet("{nombre}")]
    public async Task<string> GetNombre([FromRoute] string nombre)
    {
        var execute = await this.QueryDispatcher.Execute(new GetNombre(){Nombre = nombre});
        return execute;
    }
}
