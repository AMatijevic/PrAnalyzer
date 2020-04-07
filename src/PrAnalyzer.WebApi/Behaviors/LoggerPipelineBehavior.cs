using MediatR;
using Microsoft.Extensions.Logging;
using PrAnalyzer.Contracts.Enum;
using PrAnalyzer.Contracts.Interface;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrAnalyzer.WebApi.Behaviors
{
    public class LoggerPipelineBehavior<TRequest, TResponse>
     : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class, IHandlerResult
    {
        private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggerPipelineBehavior(ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                _logger.LogInformation($"Start request: {typeof(TRequest).Name}");
                var response = await next();
                _logger.LogInformation($"End request:{typeof(TRequest).Name}");
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred: {typeof(TRequest).Name}, message: {ex}");
                var handlerValueType = next?.Method?.ReturnType?.GetGenericArguments()?.FirstOrDefault()?.GetGenericArguments()?.FirstOrDefault();
                var genericHandler = typeof(HandlerResult<>);
                Type[] typeArgs = { handlerValueType };
                var resultType = genericHandler.MakeGenericType(typeArgs);
                return Activator.CreateInstance(resultType, default, HandlerCallStatus.InvalidOperation, ex.Message) as TResponse;
            }
        }
    }
}
