using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FruitCart.Checkout.Command.PlaceOrder.Factories;
using FruitCart.Checkout.Command.PlaceOrder.Models;
using Xunit;

namespace FruitCart.Checkout.Tests.UnitTest.Factories.Given_Some_Fruits
{
    public class When_An_Order_Is_Created_Without_Unknowns : IClassFixture<FactoryFixture>
    {
        private readonly FactoryFixture factoryFixture;
        public When_An_Order_Is_Created_Without_Unknowns(FactoryFixture factoryFixture)
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
            this.factoryFixture.Result.OrderLines.Count().Should().Be(3);
        }

        [Fact]
        public void It_Should_Have_The_Correct_Number_Of_Apples()
        {
            this.factoryFixture.Result.OrderLines.Where(orderline => orderline.ProductOrdered.Fruit.Type == Command.PlaceOrder.Models.FruitType.Apple)
            .Count()
            .Should()
            .Be(2);
        }

        [Fact]
        public void It_Should_Have_The_Correct_Number_Of_Oranges()
        {
            this.factoryFixture.Result.OrderLines.Where(orderline => orderline.ProductOrdered.Fruit.Type == Command.PlaceOrder.Models.FruitType.Orange)
            .Count()
            .Should()
            .Be(1);
        }

        [Fact]
        public void It_Should_Only_Contain_Golden_Delicious_Apples()
        {
            this.factoryFixture.Result.OrderLines.Where(orderline => orderline.ProductOrdered.Fruit.Name == "Golden Delicious")
            .Count()
            .Should()
            .Be(2);
        }

        [Fact]
        public void It_Should_Only_Contain_Jaffa_Orangess()
        {
            this.factoryFixture.Result.OrderLines.Where(orderline => orderline.ProductOrdered.Fruit.Name == "Jaffa")
            .Count()
            .Should()
            .Be(1);
        }

        [Fact]
        public void It_Should_Total_The_Correct_Value()
        {
            this.factoryFixture.Result.CalculateTotalCost();
            this.factoryFixture.Result.TotalCost.Value.Should().Be(1.45m);
        }

        private void Act()
        {
            this.factoryFixture.Result = this.factoryFixture.Sut.Create(Fruits());
        }


        private IEnumerable<string> Fruits()
        {
            yield return "Apple";
            yield return "Orange";
            yield return "Apple";
        }

    }
}