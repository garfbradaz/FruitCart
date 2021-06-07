using FruitCart.Checkout.Command.PlaceOrder.Factories;
using FruitCart.Checkout.Command.PlaceOrder.Rules;
using FruitCart.Checkout.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FruitCart.Checkout
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FruitCart.Checkout", Version = "v1" });
            });


            services.AddTransient<IOrderEntityFactory, OrderEntityFactory>()
                    .AddTransient<IFruitEntityFactory, FruitEntityFactory>()
                    .AddTransient<BogOffRuleForApples>()
                    .AddTransient<ThreeForThePriceOfTwoRuleForOranges>();

            services.AddMediatR(typeof(Startup))
                    .AddMeditrPipelineRegistrations();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FruitCart.Checkout v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
