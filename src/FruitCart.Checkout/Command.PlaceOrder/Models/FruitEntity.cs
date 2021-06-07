using System;
using FruitCart.Checkout.Shared.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Models
{
    public class FruitEntity : EntityBase
    {
        public FruitValueObject Fruit { get; set; }

        public MoneyValueObject Cost { get; set; }

        public bool OnOffer { get; set; }

    }
}