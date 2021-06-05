using System;

namespace FruitCart.Checkout.Command.PlaceOrder.Models
{
    public class FruitOrderDetailEntity
    {
        public Guid Id { get; set; }

        public FruitEntity ProductOrdered { get; set; }

    }
}