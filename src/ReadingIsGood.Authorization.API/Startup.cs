using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadingIsGood.Business.DTO.Internal;
using ReadingIsGood.Business.Middleware;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Service;

namespace ReadingIsGood.Authorization.API
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
            services.AddCors();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();

            services.AddControllers();
            Helper.SwaggerHelper.AddSwagger(services, "ReadingIsGood.Authorization.API", "v1");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReadingIsGood.Authorization.API v1"));
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
