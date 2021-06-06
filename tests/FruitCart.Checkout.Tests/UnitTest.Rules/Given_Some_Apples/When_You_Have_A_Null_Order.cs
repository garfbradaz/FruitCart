using FluentAssertions;
using Xunit;

namespace FruitCart.Checkout.Tests.UnitTest.Rules.Given_Some_Apples
{
    public class When_You_Have_Null_Order : IClassFixture<RuleFixture>
    {
        private readonly RuleFixture fixture;

        public When_You_Have_Null_Order(RuleFixture fixture)
        {
            this.fixture = fixture;
            Act();
        }

        [Fact]
        public void It_Order_Should_Be_Null()
        {
            this.fixture.Order.Should().BeNull();
        }

        [Fact]
        public void It_Cost_Nothing()
        {
            this.fixture.Result.Should().Be(0.0m);
        }

        public void Act()
        {
            this.fixture.Order = null;
            this.fixture.Result = this.fixture.Sut.ReCalculateTotalCost(this.fixture.Order);
        }
    }
}