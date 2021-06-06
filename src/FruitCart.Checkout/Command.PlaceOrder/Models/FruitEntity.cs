using System;
using FruitCart.Checkout.Shared.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Models
{
    public class FruitEntity
    {
        public Guid Id { get; set; }

        public FruitValueObject Fruit { get; set; }

        public MoneyValueObject Cost { get; set; }

    }
}