using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadingIsGood.Handler;
using ReadingIsGood.Helper;

namespace ReadingIsGood.Order.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            Configuration = ConfigurationHelper.Build(webHostEnvironment.EnvironmentName);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Configure(env.IsDevelopment());
        }
    }
}