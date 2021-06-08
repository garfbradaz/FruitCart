using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FruitCart.Products.Query.GetProducts
{
    public record GetProductResponse
    {
        [JsonInclude]
        public IEnumerable<string> Fruits { get; init; }
    }
}