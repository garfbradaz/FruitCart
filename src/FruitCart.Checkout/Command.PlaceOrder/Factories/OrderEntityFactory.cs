using System;
using System.Collections.Generic;
using System.Linq;
using FruitCart.Checkout.Command.PlaceOrder.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Factories
{

    public class OrderEntityFactory : IOrderEntityFactory
    {
        private readonly IFruitEntityFactory fruitEntityFactory;

        public OrderEntityFactory(IFruitEntityFactory fruitEntityFactory)
        {
            this.fruitEntityFactory = fruitEntityFactory;
        }

        public OrderEntity Create(IEnumerable<string> fruits, bool fruitsOnOffer = false)
        {
            return new OrderEntity()
            {
                Id = Guid.NewGuid(),
                DateAndTimeOrderPlaced = DateTime.UtcNow,
                OrderLines = CreateFruitOrderEntries(fruits, fruitsOnOffer)
            };
        }

        private IEnumerable<FruitOrderDetailEntity> CreateFruitOrderEntries(IEnumerable<string> fruits, bool fruitsOnOffer)
        {
            List<FruitOrderDetailEntity> result = new List<FruitOrderDetailEntity>();
            
            foreach (var fruit in fruits ?? Enumerable.Empty<string>())
            {
                if (Enum.TryParse<FruitType>(fruit, true, out FruitType type))
                {
                    result.Add(new FruitOrderDetailEntity()
                    {
                        Id = Guid.NewGuid(),
                        ProductOrdered = fruitEntityFactory.Create(type, fruitsOnOffer)
                    });
                }
            }

            return result;
        }
    }
}