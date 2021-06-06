using FruitCart.Checkout.Command.PlaceOrder.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Factories
{
    public interface IFruitEntityFactory
    {
        FruitEntity Create(FruitType type);
    }
}