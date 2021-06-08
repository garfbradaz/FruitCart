using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FruitCart.Products.Query.GetProducts;
using FruitCart.Products.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace FruitCart.Products.Tests.IntegrationTests.GetProducts.Given_A_Request_For_All_Products
{
    public class IntegrationTestFixture 
    {
        private readonly TestServer server;

        public HttpClient Client { get; private set; }

        public HttpResponseMessage Response { get; private set; }

        public GetProductResponse ResponseContent { get; private set; }

        public IntegrationTestFixture()
        {
            this.server = new TestServer(new WebHostBuilder()
                                    .UseStartup<Startup>());

            this.Client = server.CreateClient();
        }

        public async Task Act()
        {
            
            this.Response = await this.Client.GetAsync($"{Constants.BaseRoute.ProductManagement}/{Constants.ResourcePath.Products}");

            this.ResponseContent = await this.Response.Content.ReadFromJsonAsync<GetProductResponse>();

        }
    }
}