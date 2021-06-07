using System.Collections.Generic;
using System.Linq;
using FruitCart.Checkout.Command.PlaceOrder.Models;
using FruitCart.Checkout.Shared.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Rules
{
    public sealed class BogOffRuleForApples : IOfferRule
    {
        public decimal ReCalculateTotalCost(OrderEntity order)
        {
            if (order == null)
            {
                return default;    //Dont want to bomb out.
            }

            if (!AreThereApples(order))
            {
                return default;
            }

            var savedOrder = order.Clone() as OrderEntity;

            savedOrder.OrderLines = ClearCostEverySecondOrderLine();

            savedOrder.CalculateTotalCost();

            return savedOrder.TotalCost.Value;

            IEnumerable<FruitOrderDetailEntity> ClearCostEverySecondOrderLine()
            {
                var listOfOrders = savedOrder.OrderLines.Where(orderline => orderline.ProductOrdered.Fruit.Type == FruitType.Apple).ToList() ?? new List<FruitOrderDetailEntity>();

                var count = 1;

                foreach(var listOrder in listOfOrders)
                {
                    if (IsEven(count))
                    {
                        listOrder.ProductOrdered.Cost = MoneyValueObject.Create(default, CurrencyISO.GBP);
                    }

                    count++;
                }

                return listOfOrders;
            }
        }

        private bool AreThereApples(OrderEntity order)
        {
            return order.OrderLines?.Count(orderline => orderline.ProductOrdered.Fruit.Type == FruitType.Apple) > 0;
        }

        private bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}