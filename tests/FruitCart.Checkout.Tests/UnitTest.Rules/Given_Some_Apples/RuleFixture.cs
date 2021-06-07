using FruitCart.Checkout.Command.PlaceOrder.Factories;
using FruitCart.Checkout.Command.PlaceOrder.Models;
using FruitCart.Checkout.Command.PlaceOrder.Rules;

namespace FruitCart.Checkout.Tests.UnitTest.Rules.Given_Some_Apples
{
    public class RuleFixture
    {
        public  OrderEntityFactory Factory { get; private set; }

        public BogOffRuleForApples Sut { get; private set; }

        public  OrderEntity Order { get; set; }

        public decimal Result { get; set; }

        public RuleFixture()
        {
            this.Factory = new OrderEntityFactory(new FruitEntityFactory());
            this.Sut = new BogOffRuleForApples();
        }

    }
}