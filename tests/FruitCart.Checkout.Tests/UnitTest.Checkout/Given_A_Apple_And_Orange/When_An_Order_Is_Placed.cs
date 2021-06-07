using System;
using System.Collections.Generic;
using FluentAssertions;
using FruitCart.Checkout.Command.PlaceOrder.Models;
using FruitCart.Checkout.Shared.Models;
using Xunit;

namespace FruitCart.Checkout.Tests.UnitTest.Given_A_Apple_And_Orange
{
    public class When_An_Order_Is_Placed
    {
        private OrderEntity sut;

        private const decimal expectedCost = 2.05m;

        public When_An_Order_Is_Placed()
        {
            Arrange();
            Act();
        }

        [Fact]
        public void Its_Total_Cost_Is_Calcuated()
        {
            expectedCost.Should().Be(sut.TotalCost.Value);
        }

        private void Arrange()
        {
            this.sut = new OrderEntity()
            {
                Id = Guid.NewGuid(),
                DateAndTimeOrderPlaced = DateTime.UtcNow,
                OrderLines = this.CreateOrderEntities()

            };
        }

        private void Act()
        {
            this.sut.CalculateTotalCost();
        }

        private IEnumerable<FruitOrderDetailEntity> CreateOrderEntities()
        {
            var goldenDelicious = FruitValueObject.Create("Golden Delicious", FruitType.Apple);
            var jaffaOrange = FruitValueObject.Create("Jaffa", FruitType.Orange);

            var appleCost = MoneyValueObject.Create(0.60m, CurrencyISO.GBP);
            var orangeCost = MoneyValueObject.Create(0.25m, CurrencyISO.GBP);

            return new List<FruitOrderDetailEntity>()
        {
            new FruitOrderDetailEntity{ Id = Guid.NewGuid(), ProductOrdered = new FruitEntity(){ Id = Guid.NewGuid(), Fruit = goldenDelicious, Cost = appleCost}},
            new FruitOrderDetailEntity{ Id = Guid.NewGuid(), ProductOrdered = new FruitEntity(){ Id = Guid.NewGuid(), Fruit = goldenDelicious, Cost = appleCost}},
            new FruitOrderDetailEntity{ Id = Guid.NewGuid(), ProductOrdered = new FruitEntity(){ Id = Guid.NewGuid(), Fruit = jaffaOrange, Cost = orangeCost}},
            new FruitOrderDetailEntity{ Id = Guid.NewGuid(), ProductOrdered = new FruitEntity(){ Id = Guid.NewGuid(), Fruit = goldenDelicious, Cost = appleCost}}
        };
        }
    }
}