using System;
using FruitCart.Checkout.Command.PlaceOrder.Models;
using FruitCart.Checkout.Shared;

namespace FruitCart.Checkout.Command.PlaceOrder.Factories
{
    public class FruitEntityFactory : IFruitEntityFactory
    {
        /*TODO: inmemory implementation, but we should really the default values from a data store.
        */
        private const decimal applesDefaultValue = 0.60m;
        private const decimal orangesDefaultValue = 0.25m;
        private const CurrencyISO defaultCurrency = CurrencyISO.GBP;

        public FruitEntity Create(FruitType type)
        {
            /*For now lets just set this stuff up InMemory*/

            switch(type)
            {
                case FruitType.Apple:
                    var goldenDelicious = FruitValueObject.Create("Golden Delicious", type);
                    return CreateFruitEntity(goldenDelicious, applesDefaultValue, defaultCurrency);

                case FruitType.Orange:
                    var jaffaOrange = FruitValueObject.Create("Jaffa", type);
                    return CreateFruitEntity(jaffaOrange, orangesDefaultValue, defaultCurrency);

                default:
                    var unknown = FruitValueObject.Create("Unknown Fruit", FruitType.Unknown);
                    return CreateFruitEntity(unknown, 0.0m, defaultCurrency);
            }
        }

        private static FruitEntity CreateFruitEntity(FruitValueObject fruitValueObject, decimal costValue, CurrencyISO currency)
        {
            return new FruitEntity()
            {
                Id = Guid.NewGuid(),
                Fruit = fruitValueObject,
                Cost = MoneyValueObject.Create(costValue, defaultCurrency)
            };
        }
    }
}