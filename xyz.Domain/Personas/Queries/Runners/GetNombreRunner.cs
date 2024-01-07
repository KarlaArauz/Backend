using Ardalis.Specification;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain.Repository;
using Enee.Core.Domain.Specs;
using xyz.Domain.Personas.Projections;

namespace xyz.Domain.Personas.Queries.Runners;

public class GetNombreRunner:IQueryRunner<GetNombre,string>
{
    public IReadOnlyRepository<PersonaDocumento> Repository { get; }

    public GetNombreRunner(IReadOnlyDocumentRepository<PersonaDocumento> repository)
    {
        Repository = repository;
    }
    public async Task<string> Run(GetNombre query)
    {
        var spec = new SpecificationGeneric<PersonaDocumento, string>();
        spec.Query.Where(x=>x.Nombre==query.Nombre);
        spec.Query.Select(x => x.Apellido);
        return Repository.AsQueryable(spec).FirstOrDefault()!;
        
        
    }
}