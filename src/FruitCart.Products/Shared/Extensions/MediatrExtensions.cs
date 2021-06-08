using FruitCart.Products.Query.GetProducts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FruitCart.Products.Shared.Extensions
{

    public static class MediatrExtensions
    {
        public static IServiceCollection AddMeditrPipelineRegistrations(this IServiceCollection service)
        {
            /*Have to register in order you wish them to fire off*/
            service
                .AddTransient(typeof(IPipelineBehavior<GetProductQuery, GetProductResponse>), typeof(GetAllProductsHandler));

            return service;
        }
    }
}