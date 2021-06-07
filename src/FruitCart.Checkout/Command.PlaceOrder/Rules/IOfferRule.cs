using FruitCart.Checkout.Command.PlaceOrder.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Rules
{
    public interface IOfferRule
    {
        decimal ReCalculateTotalCost(OrderEntity order);
    }
}