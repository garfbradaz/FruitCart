using System.Collections.Generic;
using FruitCart.Checkout.Command.PlaceOrder;

namespace FruitCart.Checkout.Tests.Shared.TestDoubles
{
    public class TestPlaceOrderRequestWithTwoApplesAndAnOrange : PlaceOrderRequest
    {
        public TestPlaceOrderRequestWithTwoApplesAndAnOrange()
        {
            this.Fruits = CreateFruits();
        }

        private IEnumerable<string> CreateFruits()
        {
            yield return "Apple";
            yield return "Orange";
            yield return "Apple";
        }
    }
}