using System.Threading.Tasks;
using FluentAssertions;
using FruitCart.Checkout.Tests.Shared.TestDoubles;
using Xunit;

namespace FruitCart.Checkout.Tests.IntegrationTest.PlaceOrder.Given_Some_Fruit
{
    public class When_An_Order_Placed_With_Wonky_Case : IClassFixture<IntegrationTestFixture>, IAsyncLifetime
    {
        private readonly IntegrationTestFixture testFixture;

        public When_An_Order_Placed_With_Wonky_Case(IntegrationTestFixture testFixture)
        {
            this.testFixture = testFixture;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            this.testFixture.Request = new TestPlaceOrderRequestWithWonkyCase();

            await this.testFixture.Act();
        }

        [Fact]
        public void It_Should_Return_An_OK_Response()
        {
            this.testFixture.Response.EnsureSuccessStatusCode();
        }

        [Fact]
        public void Its_Response_Content_Should_Not_Be_Null()
        {
            this.testFixture.ResponseContent.Should().NotBeNull();
        }

        [Fact]
        public void Its_Total_Cost_Should_Be_Correct()
        {
            this.testFixture.ResponseContent.TotalCostOfOrder.Should().Be(1.45m);
        }

    }
}