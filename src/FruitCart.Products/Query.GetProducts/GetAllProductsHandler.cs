using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FruitCart.Products.Query.GetProducts
{
    public class GetAllProductsHandler : IPipelineBehavior<GetProductQuery, GetProductResponse>
    {
        public Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken, RequestHandlerDelegate<GetProductResponse> next)
        {
            string[] fruits = ManuallyCreateFruits();

            var response = new GetProductResponse() { Fruits = fruits };

            return Task.FromResult(response);

            static string[] ManuallyCreateFruits()
            {
                return new string[] { "Apple", "Orange" };
            }
        }
    }
}