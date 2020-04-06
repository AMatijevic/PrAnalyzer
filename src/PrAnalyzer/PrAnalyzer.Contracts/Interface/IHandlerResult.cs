using PrAnalyzer.Contracts.Enum;
using System.Collections.Generic;

namespace PrAnalyzer.Contracts.Interface
{
    public interface IHandlerResult
    {
        IEnumerable<string> Messages { get; }
        HandlerCallStatus Status { get; }
    }
}
