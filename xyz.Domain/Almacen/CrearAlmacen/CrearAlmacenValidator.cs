using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace xyz.Domain.Almacen.CrearAlmacen;

public class CrearAlmacenValidator:AbstractValidator<CrearAlmacenCommand>
{
    public CrearAlmacenValidator()
    {
        RuleFor(x=>x.Nombre).NotEmpty().NotNull().WithMessage("Debe tener un nombre valido");
        RuleFor(x=>x.NombreAdmin).NotEmpty().NotNull().WithMessage("Debe tener un nombre de administrador valido");
        RuleFor(x=>x.Telefono).NotEmpty().NotNull().WithMessage("Debe tener un telefono valido");
        RuleFor(x=>x.Direccion).NotEmpty().NotNull().WithMessage("Debe tener una direccion valida");
    }
}
