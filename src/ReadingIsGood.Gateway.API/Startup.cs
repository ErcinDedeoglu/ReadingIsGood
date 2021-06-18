using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMLib.Ocelot.Provider.AppConfiguration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ReadingIsGood.Gateway.API
{
    public class Startup
    {

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext(Configuration.GetConnectionString("DefaultConnection"), Configuration.GetValue<string>("MigrationName"));
            services.AddOcelot()
                .AddAppConfiguration();
            services.AddSwaggerForOcelot(Configuration);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseSwagger();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseStaticFiles();
            var headers = Configuration.GetSection("Headers").Get<Dictionary<string, string>>();
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.DownstreamSwaggerHeaders = headers;
                opt.PathToSwaggerGenerator = "/swagger/docs";
            }).UseOcelot().Wait();
        }
    }
}