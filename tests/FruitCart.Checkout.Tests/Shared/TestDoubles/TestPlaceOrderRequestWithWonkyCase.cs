using System.Collections.Generic;
using FruitCart.Checkout.Command.PlaceOrder;
using FruitCart.Checkout.Tests.Shared.Extensions;

namespace FruitCart.Checkout.Tests.Shared.TestDoubles
{
    public class TestPlaceOrderRequestWithWonkyCase : PlaceOrderRequest
    {
        public TestPlaceOrderRequestWithWonkyCase()
        {
            this.Fruits = CreateFruits();
        }

        private IEnumerable<string> CreateFruits()
        {
            return FruitData.WithWonkyNamingCase();
        }
    }
}