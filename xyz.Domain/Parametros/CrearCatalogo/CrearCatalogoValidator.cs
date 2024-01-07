using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace xyz.Domain.Parametros.CrearCatalogo;

public class CrearCatalogoValidator:CommandValidatorBase<CrearCatalogoCommand>
{
    public CrearCatalogoValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().NotNull();
    }
}