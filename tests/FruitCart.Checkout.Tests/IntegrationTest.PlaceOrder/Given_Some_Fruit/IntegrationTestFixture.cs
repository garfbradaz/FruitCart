using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FruitCart.Checkout.Command.PlaceOrder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace FruitCart.Checkout.Tests.IntegrationTest.PlaceOrder.Given_Some_Fruit
{
    public class IntegrationTestFixture 
    {
        private readonly TestServer server;

        public HttpClient Client { get; private set; }

        public PlaceOrderRequest Request { get; set;}

        public HttpResponseMessage Response { get; private set; }

        public PlaceOrderResponse ResponseContent { get; private set; }

        public IntegrationTestFixture()
        {
            this.server = new TestServer(new WebHostBuilder()
                                    .UseStartup<Startup>());

            this.Client = server.CreateClient();
        }

        public async Task Act()
        {
            var json = JsonSerializer.Serialize(Request);
            
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            this.Response = await this.Client.PostAsync("api/v1/checkout/placeorder",content);

            this.ResponseContent = await this.Response.Content.ReadFromJsonAsync<PlaceOrderResponse>();

        }
    }
}