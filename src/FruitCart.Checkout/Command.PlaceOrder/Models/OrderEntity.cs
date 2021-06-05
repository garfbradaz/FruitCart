using System;
using System.Collections.Generic;
using System.Linq;
using FruitCart.Checkout.Shared;

namespace FruitCart.Checkout.Command.PlaceOrder.Models
{
    public class OrderEntity
    {
        public Guid Id { get; set; }

        public DateTime DateAndTimeOrderPlaced { get; set; }

        public MoneyValueObject TotalCost { get; private set; }

        public IEnumerable<FruitOrderDetailEntity> OrderLines { get; set; }

        public void CalculateTotalCost()
        {
            var totalCost = this.OrderLines.Select(x => x.ProductOrdered.Cost.Value)
                                            .Sum();

            /*TODO: Logic around Multi Currency*/

            this.TotalCost = MoneyValueObject.Create(totalCost, CurrencyISO.GBP);


        }
    }
}