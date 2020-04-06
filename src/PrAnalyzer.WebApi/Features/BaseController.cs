using Microsoft.AspNetCore.Mvc;
using PrAnalyzer.Contracts.Enum;
using PrAnalyzer.Contracts.Interface;
using System;
using System.Linq;

namespace PrAnalyzer.WebApi.Features
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Maps <see cref="HandlerResult{TValue}"/> to <see cref="ActionResult{TValue}"/>
        /// with suitable HTTP error codes.
        /// </summary>
        protected ActionResult<TValue> FromValueHandlerResult<TValue>(HandlerResult<TValue> result)
        {
            return result.Status switch
            {
                HandlerCallStatus.Ok => Ok(result.Value),
                HandlerCallStatus.Created => Created(string.Empty, result.Value),
                HandlerCallStatus.EntityNotFound => NotFound(result.Messages.Any() ? result.Messages : new string[] { "Entity not found." }),
                HandlerCallStatus.UnauthorizedAccess => Unauthorized(),
                HandlerCallStatus.InvalidOperation => BadRequest(result.Messages),
                HandlerCallStatus.InvalidEntity => BadRequest(result.Messages),
                _ => throw new NotImplementedException(),
            };
        }

        /// <summary>
        /// Maps <see cref="IHandlerResult"/> to <see cref="IActionResult"/>
        /// with suitable HTTP error codes.
        /// </summary>
        protected IActionResult FromHandlerResult(IHandlerResult result)
        {
            return result.Status switch
            {
                HandlerCallStatus.Ok => Ok(),
                HandlerCallStatus.EntityNotFound => NotFound(result.Messages),
                HandlerCallStatus.UnauthorizedAccess => Unauthorized(),
                HandlerCallStatus.InvalidOperation => BadRequest(result.Messages),
                HandlerCallStatus.InvalidEntity => BadRequest(result.Messages),
                _ => throw new NotImplementedException(),
            };
        }

    }
}
