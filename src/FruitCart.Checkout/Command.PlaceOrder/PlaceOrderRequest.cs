using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class PlaceOrderRequest
    {
        [JsonInclude]
        public IEnumerable<string> Fruits { get; protected set; }

        public static PlaceOrderRequest Create(IEnumerable<string> fruits)
        {
            return new PlaceOrderRequest()
            {
                Fruits = fruits
            };
        }
    }
}