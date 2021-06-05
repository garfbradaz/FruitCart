using System.Collections.Generic;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class PlaceOrderRequest
    {
        public IEnumerable<string> Fruits { get; set; }
    }
}