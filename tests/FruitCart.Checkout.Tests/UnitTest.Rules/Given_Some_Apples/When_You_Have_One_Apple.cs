using System.Linq;
using FluentAssertions;
using FruitCart.Checkout.Tests.Shared.Extensions;
using Xunit;

namespace FruitCart.Checkout.Tests.UnitTest.Rules.Given_Some_Apples
{
    public class When_You_Have_One_Apple : IClassFixture<RuleFixture>
    {
        private const int totalApples = 1;

        private readonly RuleFixture fixture;

        public When_You_Have_One_Apple(RuleFixture fixture)
        {
            this.fixture = fixture;
            Act();
        }

        [Fact]
        public void It_Order_Should_Not_Be_Null()
        {
            this.fixture.Order.Should().NotBeNull();
        }

        [Fact]
        public void It_Should_Have_The_Correct_Orderlines()
        {
            this.fixture.Order.OrderLines.Count().Should().Be(totalApples);
        }

        [Fact]
        public void It_Total_Cost_Should_Be_Full_Price()
        {
            this.fixture.Result.Should().Be(0.60m);
        }

        public void Act()
        {
            this.fixture.Order = this.fixture.Factory.Create(FruitData.WithXAmountOf(totalApples));
            this.fixture.Result = this.fixture.Sut.ReCalculateTotalCost(this.fixture.Order);
        }
    }
}