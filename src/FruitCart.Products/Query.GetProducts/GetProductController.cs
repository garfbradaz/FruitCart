using System.Threading.Tasks;
using FruitCart.Products.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitCart.Products.Query.GetProducts
{
    [Route(Constants.BaseRoute.ProductManagement)]
    public class GetProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public GetProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route(Constants.ResourcePath.Products)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(GetProductResponse))]
        public async Task<IActionResult> Products()
        {
            var result = await mediator.Send(new GetProductQuery());
            return Ok(result);
        }

    }
}