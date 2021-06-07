using System.Collections.Generic;
using FruitCart.Checkout.Command.PlaceOrder.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Factories
{
    public interface IOrderEntityFactory
    {
        OrderEntity Create(IEnumerable<string> fruits,  bool fruitsOnOffer = false);
    }
}