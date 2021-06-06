using System.Threading;
using System.Threading.Tasks;
using FruitCart.Checkout.Command.PlaceOrder.Factories;
using MediatR;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class CalculateTotalOrderWithoutDeals : IRequestHandler<PlaceOrderCommand, PlaceOrderResponse>
    {
        private readonly IOrderEntityFactory orderEntityFactory;
        
        public CalculateTotalOrderWithoutDeals(IOrderEntityFactory orderEntityFactory)
        {
            this.orderEntityFactory = orderEntityFactory;
        }

        public Task<PlaceOrderResponse> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            var order = this.orderEntityFactory.Create(request.Fruits);

            order.CalculateTotalCost();

            return Task.FromResult(PlaceOrderResponse.Create(order.TotalCost.Value));
        }

    }
}