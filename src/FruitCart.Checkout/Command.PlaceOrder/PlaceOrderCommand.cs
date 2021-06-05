using System.Collections.Generic;
using MediatR;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class PlaceOrderCommand : IRequest<PlaceOrderResponse>
    {
        public IEnumerable<string> Fruits { get; private set; }

        private PlaceOrderCommand()
        { 
        }

        public static PlaceOrderCommand Create(IEnumerable<string> fruits)
        {
            return new PlaceOrderCommand()
            {
                Fruits = fruits
            };
        }
    }
}