using PrAnalyzer.Contracts.Enum;
using PrAnalyzer.Contracts.Interface;
using PrAnalyzer.Core.Entities;
using System.Collections.Generic;

namespace PrAnalyzer.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        //Connection to DB, DBContext EFCore or similar ORM's
        private List<IProduct> Products = new List<IProduct>
        {
            new Product("Basic electricity tariff", ProductType.Basic),

            new Product("Packaged tariff", ProductType.Package)
        };

        public IEnumerable<IProduct> GetProducts()
        {
            return Products ?? new List<IProduct>();
        }
    }
}
