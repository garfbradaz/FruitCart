using System;

namespace FruitCart.Checkout.Shared.Models
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}