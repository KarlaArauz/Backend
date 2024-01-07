using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace xyz.Domain.Personas.Commands.Validator;

public class EditarPersonaValidator:CommandValidatorBase<EditarPersona>
{
    public EditarPersonaValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().NotNull();
    }
    
}