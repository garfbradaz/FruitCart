using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, PlaceOrderResponse>
    {
        public Task<PlaceOrderResponse> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(PlaceOrderResponse.CreateEmpty());
        }
    }
}