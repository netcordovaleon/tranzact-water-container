using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tranzact.WaterContainer.App.Services;
using Tranzact.WaterContainer.App.Operators;
using Tranzact.WaterContainer.App.Shared;

namespace Tranzact.WaterContainer.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            IoCContainer(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        protected void IoCContainer(IServiceCollection services) {
            services.AddSingleton<IWaterContainerServices, WaterContainerServices>();
            services.AddSingleton<IWaterContainerOperator, WaterContainerOperator>();
        }
    }
}
