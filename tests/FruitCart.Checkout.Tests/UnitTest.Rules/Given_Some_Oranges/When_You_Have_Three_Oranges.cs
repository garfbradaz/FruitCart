using System.Linq;
using FluentAssertions;
using FruitCart.Checkout.Tests.Shared.Extensions;
using Xunit;

namespace FruitCart.Checkout.Tests.UnitTest.Rules.Given_Some_Oranges
{
    public class When_You_Have_Three_Oranges : IClassFixture<RuleFixture>
    {
        private const int totalOranges = 3;

        private readonly RuleFixture fixture;

        public When_You_Have_Three_Oranges(RuleFixture fixture)
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
            this.fixture.Order.OrderLines.Count().Should().Be(totalOranges);
        }

        [Fact]
        public void It_Total_Cost_Should_Be_The_Correct_Price()
        {
            this.fixture.Result.Should().Be(0.50m);
        }

        public void Act()
        {
            this.fixture.Order = this.fixture.Factory.Create(FruitData.WithXAmountOf(totalOranges, "Orange"));
            this.fixture.Result = this.fixture.Sut.ReCalculateTotalCost(this.fixture.Order);
        }
    }
}