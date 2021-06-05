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