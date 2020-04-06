using PrAnalyzer.Contracts.Enum;
using System.Collections.Generic;
using System.Linq;

namespace PrAnalyzer.Contracts.Interface
{
    public sealed class HandlerResult<TValue> : IHandlerResult
    {
        public TValue Value { get; }
        public IEnumerable<string> Messages { get; }
        public HandlerCallStatus Status { get; }

        public HandlerResult(TValue value, HandlerCallStatus status, string message)
            : this(value, status, new[] { message })
        {
        }

        public HandlerResult(TValue value, HandlerCallStatus status, IEnumerable<string> messages = null)
        {
            Value = value;
            Status = status;
            Messages = messages ?? Enumerable.Empty<string>();
        }
    }

    public sealed class HandlerResult : IHandlerResult
    {
        public IEnumerable<string> Messages { get; }
        public HandlerCallStatus Status { get; }

        private HandlerResult(HandlerCallStatus status, string message)
            : this(status, new[] { message })
        {
        }

        private HandlerResult(HandlerCallStatus status, IEnumerable<string> messages = null)
        {
            Status = status;
            Messages = messages ?? Enumerable.Empty<string>();
        }

        private static readonly HandlerResult OkSingleton = new HandlerResult(HandlerCallStatus.Ok);
        public static HandlerResult Ok()
        {
            return OkSingleton;
        }

        public static HandlerResult<TResult> Ok<TResult>(TResult result)
        {
            return new HandlerResult<TResult>(result, HandlerCallStatus.Ok);
        }

        private static readonly HandlerResult CreatedSingleton = new HandlerResult(HandlerCallStatus.Ok);
        public static HandlerResult Created()
        {
            return CreatedSingleton;
        }

        public static HandlerResult<TResult> Created<TResult>(TResult result)
        {
            return new HandlerResult<TResult>(result, HandlerCallStatus.Created);
        }

        public static HandlerResult EntityNotFound()
        {
            return new HandlerResult(HandlerCallStatus.EntityNotFound);
        }

        public static HandlerResult EntityNotFound(string errorMessage)
        {
            return new HandlerResult(HandlerCallStatus.EntityNotFound, errorMessage);
        }

        public static HandlerResult<TResult> EntityNotFound<TResult>()
        {
            return new HandlerResult<TResult>(default, HandlerCallStatus.EntityNotFound);
        }

        public static HandlerResult<TResult> EntityNotFound<TResult>(TResult result)
        {
            return new HandlerResult<TResult>(result, HandlerCallStatus.EntityNotFound);
        }

        public static HandlerResult<TResult> EntityNotFound<TResult>(string errorMessage)
        {
            return new HandlerResult<TResult>(default, HandlerCallStatus.EntityNotFound, errorMessage);
        }

        public static HandlerResult UnauthorizedAccess(string errorMessage)
        {
            return new HandlerResult(HandlerCallStatus.UnauthorizedAccess, errorMessage);
        }

        public static HandlerResult<TResult> UnauthorizedAccess<TResult>(string errorMessage)
        {
            return new HandlerResult<TResult>(default, HandlerCallStatus.UnauthorizedAccess, errorMessage);
        }

        public static HandlerResult InvalidOperation(string errorMessage)
        {
            return new HandlerResult(HandlerCallStatus.InvalidOperation, errorMessage);
        }

        public static HandlerResult<TResult> InvalidOperation<TResult>(string errorMessage)
        {
            return new HandlerResult<TResult>(default, HandlerCallStatus.InvalidOperation, errorMessage);
        }

        public static HandlerResult InvalidEntity(IEnumerable<string> errorMessages)
        {
            return new HandlerResult(HandlerCallStatus.InvalidEntity, errorMessages);
        }

        public static HandlerResult InvalidEntity(string errorMessage)
        {
            return new HandlerResult(HandlerCallStatus.InvalidEntity, errorMessage);
        }

        public static HandlerResult<TResult> InvalidEntity<TResult>(string errorMessage)
        {
            return new HandlerResult<TResult>(default, HandlerCallStatus.InvalidEntity, errorMessage);
        }

        public static HandlerResult<TResult> InvalidEntity<TResult>(IEnumerable<string> errorMessages)
        {
            return new HandlerResult<TResult>(default, HandlerCallStatus.InvalidEntity, errorMessages);
        }
    }
}
