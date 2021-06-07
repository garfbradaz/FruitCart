using FruitCart.Checkout.Shared.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Models
{
    public class FruitOrderDetailEntity : EntityBase
    {
        public FruitEntity ProductOrdered { get; set; }

    }
}