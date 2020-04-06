using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrAnalyzer.Contracts.Dto;
using PrAnalyzer.WebApi.Features.Electricity.GetProducts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrAnalyzer.WebApi.Features.Electricity
{
    [Route("api/[controller]")]
    public class ElectricityController : BaseController
    {
        private readonly IMediator _mediator;

        public ElectricityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Products/{consumption:decimal}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(decimal consumption)
        {
            return FromValueHandlerResult(await _mediator.Send(new GetProductsByCostHandler.Command() { Consumption = consumption }));
        }
    }
}

