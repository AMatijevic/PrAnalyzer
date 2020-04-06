using PrAnalyzer.Contracts.Enum;
using PrAnalyzer.Contracts.Interface;

namespace PrAnalyzer.Core.Entities
{
    public class Product : IProduct
    {
        public Product(string name, ProductType type) => (Name, Type) = (name, type);

        private Product() { }

        public string Name { get; private set; }

        public ProductType Type { get; private set; }
    }
}
