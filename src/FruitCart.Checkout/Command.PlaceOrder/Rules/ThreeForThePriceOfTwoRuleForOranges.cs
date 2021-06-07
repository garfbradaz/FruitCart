using System.Collections.Generic;
using System.Linq;
using FruitCart.Checkout.Command.PlaceOrder.Models;
using FruitCart.Checkout.Shared.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Rules
{
    public sealed class ThreeForThePriceOfTwoRuleForOranges : IOfferRule
    {
        public decimal ReCalculateTotalCost(OrderEntity order)
        {
            if (order == null)
            {
                return default;    //Dont want to bomb out.
            }

            if (!AreThereOranges(order))
            {
                return default;
            }

            var savedOrder = order.Clone() as OrderEntity;

            savedOrder.OrderLines = ClearCostEveryThirdOrderLine();

            savedOrder.CalculateTotalCost();

            return savedOrder.TotalCost.Value;

            IEnumerable<FruitOrderDetailEntity> ClearCostEveryThirdOrderLine()
            {
                var listOfOrders = savedOrder.OrderLines.Where(orderline => orderline.ProductOrdered.Fruit.Type == FruitType.Orange).ToList() ?? new List<FruitOrderDetailEntity>();

                var count = 1;
                
                foreach(var listOrder in listOfOrders)
                {
                    if (IsMultipleOfThree(count))
                    {
                        listOrder.ProductOrdered.Cost = MoneyValueObject.Create(default, CurrencyISO.GBP);
                    }

                    count++;
                }

                return listOfOrders;
            }
        }

        private bool AreThereOranges(OrderEntity order)
        {
            return order.OrderLines?.Count(orderline => orderline.ProductOrdered.Fruit.Type == FruitType.Orange) > 0;
        }

        private bool IsMultipleOfThree(int number)
        {
            return number % 3 == 0;
        }
    }
}