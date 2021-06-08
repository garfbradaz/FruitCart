using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace FruitCart.Products.Tests.IntegrationTests.GetProducts.Given_A_Request_For_All_Products
{
    public class When_Products_Are_Available : IClassFixture<IntegrationTestFixture>, IAsyncLifetime
    {
        private readonly IntegrationTestFixture fixture;
        public When_Products_Are_Available(IntegrationTestFixture testFixture)
        {
            this.fixture = testFixture;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            await this.fixture.Act();
        }

        [Fact]
        public void It_Should_Be_A_Success()
        {
            this.fixture.Response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("Apple")]
        [InlineData("Orange")]
        public void It_Should_Include_Correct_Values(string fruitName)
        {
            this.fixture.ResponseContent.Fruits.Should().Contain(fruitName);
        }
    }
}