using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadingIsGood.Business.DTO.Internal;
using ReadingIsGood.Business.Middleware;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Service;
using ReadingIsGood.Helper;

namespace ReadingIsGood.Customer.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment webHostEnvironment)
        {
            Configuration = Helper.ConfigurationHelper.Build(webHostEnvironment.EnvironmentName);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddControllers();

            SwaggerHelper.AddSwagger(services, "ReadingIsGood.Customer.API", "v1");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReadingIsGood.Customer.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}