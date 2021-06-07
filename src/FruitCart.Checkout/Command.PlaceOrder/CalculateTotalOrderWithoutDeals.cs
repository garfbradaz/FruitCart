using System.Threading;
using System.Threading.Tasks;
using FruitCart.Checkout.Command.PlaceOrder.Factories;
using MediatR;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class CalculateTotalOrderWithoutDeals : IPipelineBehavior<PlaceOrderCommand,PlaceOrderResponse>
    {
        private readonly IOrderEntityFactory orderEntityFactory;
        
        public CalculateTotalOrderWithoutDeals(IOrderEntityFactory orderEntityFactory)
        {
            this.orderEntityFactory = orderEntityFactory;
        }

        public async Task<PlaceOrderResponse> Handle(PlaceOrderCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<PlaceOrderResponse> next)
        {
            if(request.WithDeals)
            {
                var responseFromNextHandler = await next();
                return responseFromNextHandler;
            }

            var order = this.orderEntityFactory.Create(request.Fruits);

            order.CalculateTotalCost();

            return PlaceOrderResponse.Create(order.TotalCost.Value);
        }
    }
}