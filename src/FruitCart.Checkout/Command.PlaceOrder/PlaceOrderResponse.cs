using System.Text.Json.Serialization;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class PlaceOrderResponse
    {
        [JsonInclude]
        public decimal TotalCostOfOrder { get; private set; }

        private PlaceOrderResponse()
        {}

        [JsonConstructor]
        public PlaceOrderResponse(decimal totalCostOfOrder)
        {
            this.TotalCostOfOrder = totalCostOfOrder;
        }

        public static PlaceOrderResponse Create(decimal totalCost)
        {
            return new PlaceOrderResponse()
            {
                TotalCostOfOrder = totalCost
            };
        }

        public static PlaceOrderResponse CreateEmpty() => new PlaceOrderResponse();
    }
}