using System.Collections.Generic;
using System.Linq;

namespace FruitCart.Checkout.Tests.Shared.Extensions
{
    public static class FruitData
    {
        public static IEnumerable<string> WithTwoApplesAndAnOrange()
        {
            yield return "Apple";
            yield return "Orange";
            yield return "Apple";
        }

        public static IEnumerable<string> WithXAmountOfApples(int howMany)
        {
            if(howMany == 0)
            {
                return Enumerable.Empty<string>();
            }

            var list = new List<string>();

            for (int i = 0; i < howMany;i++)
            {
                list.Add("Apple");
            }

            return list;
        }

        public static IEnumerable<string> WithWonkyNamingCase()
        {
            yield return "apple";
            yield return "OranGe";
            yield return "APPLE";
        }

        public static IEnumerable<string> WithAllUnknown()
        {
            yield return "Pear";
            yield return "Pineapple";
            yield return "Tangerine";
        }
    }
}