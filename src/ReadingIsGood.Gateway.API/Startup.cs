using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot()
                .AddAppConfiguration();
            services.AddSwaggerForOcelot(Configuration);

            services.AddControllers();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseStaticFiles();
            var headers = Configuration.GetSection("Headers").Get<Dictionary<string, string>>();
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.DownstreamSwaggerHeaders = headers;

                opt.PathToSwaggerGenerator = "/swagger/docs";
})
                .UseOcelot()
                .Wait();
        }
    }
}
