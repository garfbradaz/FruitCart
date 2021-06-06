using System;

namespace FruitCart.Checkout.Shared.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}