using FruitCart.Checkout.Command.PlaceOrder.Factories;
using FruitCart.Checkout.Command.PlaceOrder.Models;

namespace FruitCart.Checkout.Tests.UnitTest.Factories.Given_Some_Fruits
{
    public class FactoryFixture
    {
        public  OrderEntityFactory Sut { get; private set; }
        public  OrderEntity Result { get; set; }

        public FactoryFixture()
        {
            this.Sut = new OrderEntityFactory(new FruitEntityFactory());
        }

    }
}