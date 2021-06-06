using FruitCart.Checkout.Command.PlaceOrder;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FruitCart.Checkout.Shared.Extensions
{
    public static class MediatrExtensions
    {
        public static IServiceCollection AddMeditrPipelineRegistrations(this IServiceCollection service)
        {
            service.AddTransient(typeof(IPipelineBehavior<PlaceOrderCommand,PlaceOrderResponse>), typeof(CalculateTotalOrderWithoutDeals));

            return service;
        }
    }
}