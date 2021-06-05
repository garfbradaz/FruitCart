namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class PlaceOrderResponse
    {
        public decimal TotalCostOfOrder { get; private set; }

        private PlaceOrderResponse()
        {}

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