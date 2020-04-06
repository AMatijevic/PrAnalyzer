using System.Collections.Generic;

namespace PrAnalyzer.Contracts.Interface
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetProducts();
    }
}
