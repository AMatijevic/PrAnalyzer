namespace PrAnalyzer.Contracts.Interface
{
    public interface ICostCalculator
    {
        decimal Calculate(IProduct product, decimal consumption);
    }
}
