using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadingIsGood.Business.DTO.Internal;
using ReadingIsGood.Business.Middleware;
using ReadingIsGood.Data.Interface.UOW;
using ReadingIsGood.Data.Service.UOW;
using ReadingIsGood.Helper;

namespace ReadingIsGood.Handler
{
    public static class StartupHandler
    {
        public static void Configure(this IApplicationBuilder app, bool isDevelopment)
        {
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (isDevelopment) app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Assembly.GetCallingAssembly().GetName().Name + " v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();
            app.UseExceptionHandler(ExceptionMiddleware.Init);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UpdateDatabase();
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddDbContext(configuration.GetConnectionString("DefaultConnection"),
                configuration.GetValue<string>("MigrationName"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers()
                .AddJsonOptions(o => o.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.Preserve);

            SwaggerHelper.AddSwagger(services, Assembly.GetCallingAssembly().GetName().Name, "v1");
        }
    }
}