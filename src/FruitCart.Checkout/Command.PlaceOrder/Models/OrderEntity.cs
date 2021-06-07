using System;
using System.Collections.Generic;
using System.Linq;
using FruitCart.Checkout.Shared.Models;

namespace FruitCart.Checkout.Command.PlaceOrder.Models
{
    public class OrderEntity : EntityBase, ICloneable
    {
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

        public object Clone()
        {
            var anotherOrder = (OrderEntity)this.MemberwiseClone();
            anotherOrder.DateAndTimeOrderPlaced = this.DateAndTimeOrderPlaced;
            anotherOrder.OrderLines = this.OrderLines.ToList();

            if(this.TotalCost != null)
            {
                anotherOrder.TotalCost = MoneyValueObject.Create(this.TotalCost.Value, this.TotalCost.Currency);
            }
            
            return anotherOrder;

        }
    }
}