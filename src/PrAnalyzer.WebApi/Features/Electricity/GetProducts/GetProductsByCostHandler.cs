using MediatR;
using PrAnalyzer.Contracts.Dto;
using PrAnalyzer.Contracts.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrAnalyzer.WebApi.Features.Electricity.GetProducts
{
    public sealed class GetProductsByCostHandler
    {
        public class Command : IRequest<HandlerResult<IEnumerable<ProductDto>>>
        {
            public decimal Consumption { get; set; }
        }

        public class Handler : IRequestHandler<Command, HandlerResult<IEnumerable<ProductDto>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly ICostCalculator _costCalculator;

            public Handler(IProductRepository productRepository,
                ICostCalculator costCalculator)
            {
                _productRepository = productRepository;
                _costCalculator = costCalculator;
            }

            public async Task<HandlerResult<IEnumerable<ProductDto>>> Handle(Command request, CancellationToken cancellationToken)
            {
                var products = _productRepository.GetProducts()
                    .Select(product =>
                    {
                        return new ProductDto
                        {
                            Name = product.Name,
                            AnnualCosts = _costCalculator.Calculate(product, request.Consumption)
                        };
                    })
                    .OrderBy(product => product.AnnualCosts)
                    .AsEnumerable();

                return products == null
                    ? HandlerResult.EntityNotFound<IEnumerable<ProductDto>>()
                    : HandlerResult.Ok(products);
            }
        }

    }
}
