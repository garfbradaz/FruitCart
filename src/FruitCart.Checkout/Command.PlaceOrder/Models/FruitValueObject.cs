
namespace FruitCart.Checkout.Command.PlaceOrder.Models
{
    public class FruitValueObject
    {
        public string Name { get; private set; }

        public FruitType Type { get; private set; }

        private FruitValueObject()
        { }

        public static FruitValueObject Create(string name, FruitType type)
        {
            return new FruitValueObject
            {
                Name = name,
                Type = type
            };
        }

    }

    public enum FruitType
    {
        Apple,
        Orange,
        Unknown
    }
}