using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace FruitCart.Checkout.Tests.UnitTest.Factories.Given_Some_Fruits
{
    public class When_An_Order_Is_Created_With_All_Unknown_Fruits : IClassFixture<FactoryFixture>
    {
        private readonly FactoryFixture factoryFixture;
        public When_An_Order_Is_Created_With_All_Unknown_Fruits(FactoryFixture factoryFixture)
        {
            this.factoryFixture = factoryFixture;
            Act();
        }

        [Fact]
        public void It_Should_Not_Be_Null()
        {
            this.factoryFixture.Result.Should().NotBeNull();
        }

        [Fact]
        public void It_Orderlines_Should_Not_Be_Null()
        {
            this.factoryFixture.Result.OrderLines.Should().NotBeNull();
        }

        [Fact]
        public void It_Total_Orderlines_Should_Be_Correct()
        {
            this.factoryFixture.Result.OrderLines.Count().Should().Be(0);
        }

        [Fact]
        public void It_Should_Have_No_Apples()
        {
            this.factoryFixture.Result.OrderLines.Where(orderline => orderline.ProductOrdered.Fruit.Type == Command.PlaceOrder.Models.FruitType.Apple)
            .Count()
            .Should()
            .Be(0);
        }

        [Fact]
        public void It_Should_Have_No_Oranges()
        {
            this.factoryFixture.Result.OrderLines.Where(orderline => orderline.ProductOrdered.Fruit.Type == Command.PlaceOrder.Models.FruitType.Orange)
            .Count()
            .Should()
            .Be(0);
        }

        [Fact]
        public void It_Should_Total_The_Correct_Value()
        {
            this.factoryFixture.Result.CalculateTotalCost();
            this.factoryFixture.Result.TotalCost.Value.Should().Be(0.0m);
        }

        private void Act()
        {
            this.factoryFixture.Result = this.factoryFixture.Sut.Create(Fruits());
        }


        private IEnumerable<string> Fruits()
        {
            yield return "Pear";
            yield return "Pineapple";
            yield return "Tangerine";
        }

    }
}