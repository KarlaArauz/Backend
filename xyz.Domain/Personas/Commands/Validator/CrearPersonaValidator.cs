using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace xyz.Domain.Personas.Commands.Validator;

public class CrearPersonaValidator:CommandValidatorBase<CrearPersona>
{
    public CrearPersonaValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().NotNull().NotEqual("string");
    }
}