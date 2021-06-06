using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    [Route("api/v1/checkout")]
    public class PlaceOrderController : ControllerBase
    {
        private readonly IMediator mediator;
        public PlaceOrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /*Im dying on the hill that this is a POST. The Domain OrderLine would be created as a resource and the calculated
        total cost  returned.
        
        Yes currently we are only calculating InMemory, but in the spirit of RESTful services, this is a POST*/
        [HttpPost]
        [Route("placeorder")]
        public async Task<IActionResult> PlaceOrder([FromBody]PlaceOrderRequest placeOrderRequest)
        {
            var command = PlaceOrderCommand.Create(placeOrderRequest.Fruits);

            var result = await mediator.Send(command);

            return Ok(result);
        }

    }
}