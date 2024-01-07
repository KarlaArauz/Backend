using Enee.Core.Common.Util;
using Enee.Core.CQRS.Validation;
using Microsoft.AspNetCore.Mvc;

namespace xyz.Api.Controllers.Utils;

public static class ResponseDispatcher
{
    public static IActionResult ToResponse(this Either<OK, List<MessageValidation>> result,object? value=null)
    {
        return result.Match<IActionResult>(
            ok =>  value==null? new OkResult() :new OkObjectResult(value),
            error => new BadRequestObjectResult(error)
        );
    }
    
}