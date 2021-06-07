using System.Collections.Generic;
using System.Linq;
using FruitCart.Checkout.Command.PlaceOrder;
using FruitCart.Checkout.Tests.Shared.Extensions;

namespace FruitCart.Checkout.Tests.Shared.TestDoubles
{
    public class TestPlaceOrderRequestWithTenApplesAndFourOrangesOnOffer : PlaceOrderRequest
    {
        public TestPlaceOrderRequestWithTenApplesAndFourOrangesOnOffer()
        {
            this.Fruits = CreateFruits();
            this.WithDeals = true;
        }

        private IEnumerable<string> CreateFruits()
        {
            return FruitData.WithXAmountOf(10,"Apple").Concat(FruitData.WithXAmountOf(4,"Orange"));
        }
    }
}