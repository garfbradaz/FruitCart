using System.Collections.Generic;
using MediatR;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class PlaceOrderCommand : IRequest<PlaceOrderResponse>
    {
        public IEnumerable<string> Fruits { get; private set; }

        public bool WithDeals { get; private set; }

        private PlaceOrderCommand()
        { 
        }

        public static PlaceOrderCommand Create(IEnumerable<string> fruits, bool withDeals)
        {
            return new PlaceOrderCommand()
            {
                Fruits = fruits,
                WithDeals = withDeals
            };
        }
    }
}