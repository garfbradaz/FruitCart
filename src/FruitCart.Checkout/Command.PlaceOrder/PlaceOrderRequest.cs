using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class PlaceOrderRequest
    {
        [JsonInclude]
        public IEnumerable<string> Fruits { get; protected set; }

        [JsonInclude]
        public bool WithDeals { get; protected set; }

        public static PlaceOrderRequest Create(IEnumerable<string> fruits, bool withDeals)
        {
            return new PlaceOrderRequest()
            {
                Fruits = fruits,
                WithDeals = withDeals
            };
        }
    }
}