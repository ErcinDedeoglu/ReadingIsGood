using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadingIsGood.Business.DTO.Internal;
using ReadingIsGood.Business.Middleware;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Service;
using ReadingIsGood.Handler;
using ReadingIsGood.Helper;

namespace ReadingIsGood.Order.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            Configuration = Helper.ConfigurationHelper.Build(webHostEnvironment.EnvironmentName);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext(Configuration.GetConnectionString("DefaultConnection"), Configuration.GetValue<string>("MigrationName"));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddControllers();
            SwaggerHelper.AddSwagger(services, "ReadingIsGood.Order.API", "v1");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Configure(env.IsDevelopment());
        }
    }
}