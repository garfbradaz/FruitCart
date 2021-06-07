using System.Threading;
using System.Threading.Tasks;
using FruitCart.Checkout.Command.PlaceOrder.Factories;
using FruitCart.Checkout.Command.PlaceOrder.Rules;
using MediatR;

namespace FruitCart.Checkout.Command.PlaceOrder
{
    public class CalculateTotalOrderWithDeals : IPipelineBehavior<PlaceOrderCommand, PlaceOrderResponse>
    {
        private readonly BogOffRuleForApples appleRule;

        private readonly ThreeForThePriceOfTwoRuleForOranges orangeRule;

        private readonly IOrderEntityFactory orderEntityFactory;

        public CalculateTotalOrderWithDeals(
            BogOffRuleForApples appleRule,
            ThreeForThePriceOfTwoRuleForOranges orangeRule,
            IOrderEntityFactory orderEntityFactory)
        {
            this.appleRule = appleRule;
            this.orangeRule = orangeRule;
            this.orderEntityFactory = orderEntityFactory;
        }

        public Task<PlaceOrderResponse> Handle(PlaceOrderCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<PlaceOrderResponse> next)
        {
            /*TODO: Add a ItemCacheContext that can be passed from Handler-To-Handler. This is already created upstream*/
            var order = this.orderEntityFactory.Create(request.Fruits, request.WithDeals);

            var appleOfferValue = this.appleRule.ReCalculateTotalCost(order);
            var orangeOfferValue = this.orangeRule.ReCalculateTotalCost(order);
            var totalCost = appleOfferValue + orangeOfferValue;

            return Task.FromResult(PlaceOrderResponse.Create(totalCost));
        }
    }
}