using System.Collections.Generic;
using FruitCart.Checkout.Command.PlaceOrder;
using FruitCart.Checkout.Tests.Shared.Extensions;

namespace FruitCart.Checkout.Tests.Shared.TestDoubles
{
    public class TestPlaceOrderRequestWithTwoApplesOnOffer : PlaceOrderRequest
    {
        public TestPlaceOrderRequestWithTwoApplesOnOffer()
        {
            this.Fruits = CreateFruits();
            this.WithDeals = true;
        }

        private IEnumerable<string> CreateFruits()
        {
            return FruitData.WithXAmountOf(2,"Apple");
        }
    }
}