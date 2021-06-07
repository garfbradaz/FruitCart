using FruitCart.Checkout.Command.PlaceOrder;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FruitCart.Checkout.Shared.Extensions
{
    public static class MediatrExtensions
    {
        public static IServiceCollection AddMeditrPipelineRegistrations(this IServiceCollection service)
        {
            /*Have to register in order you wish them to fire off*/
            service
                .AddTransient(typeof(IPipelineBehavior<PlaceOrderCommand,PlaceOrderResponse>), typeof(CalculateTotalOrderWithoutDeals))
                .AddTransient(typeof(IPipelineBehavior<PlaceOrderCommand,PlaceOrderResponse>), typeof(CalculateTotalOrderWithDeals));

            return service;
        }
    }
}