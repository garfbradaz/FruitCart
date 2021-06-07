using System.Collections.Generic;
using FruitCart.Checkout.Command.PlaceOrder;
using FruitCart.Checkout.Tests.Shared.Extensions;

namespace FruitCart.Checkout.Tests.Shared.TestDoubles
{
    public class TestPlaceOrderRequestWithTwoApplesAndAnOrangeOnOffer : PlaceOrderRequest
    {
        public TestPlaceOrderRequestWithTwoApplesAndAnOrangeOnOffer()
        {
            this.Fruits = CreateFruits();
            this.WithDeals = true;
        }

        private IEnumerable<string> CreateFruits()
        {
            return FruitData.WithTwoApplesAndAnOrange();
        }
    }
}