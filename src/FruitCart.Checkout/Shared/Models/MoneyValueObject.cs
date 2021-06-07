namespace FruitCart.Checkout.Shared.Models
{
    public class MoneyValueObject
    {
        public decimal Value { get; private set; }

        public CurrencyISO Currency { get; private set; }

        private MoneyValueObject()
        { }

        public static MoneyValueObject Create(decimal value, CurrencyISO currency)
        {
            return new MoneyValueObject
            {
                Value = value,
                Currency = currency
            };
        }
    }

    public enum CurrencyISO
    {
        GBP,
        EUR,
        USD
    }
}