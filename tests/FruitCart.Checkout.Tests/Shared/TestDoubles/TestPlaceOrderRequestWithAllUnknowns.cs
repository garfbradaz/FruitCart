using System.Collections.Generic;
using FruitCart.Checkout.Command.PlaceOrder;
using FruitCart.Checkout.Tests.Shared.Extensions;

namespace FruitCart.Checkout.Tests.Shared.TestDoubles
{
    public class TestPlaceOrderRequestWithAllUnknowns : PlaceOrderRequest
    {
        public TestPlaceOrderRequestWithAllUnknowns()
        {
            this.Fruits = CreateFruits();
        }

        private IEnumerable<string> CreateFruits()
        {
            return FruitData.WithAllUnknown();
        }
    }
}