using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReadingIsGood.Context;

namespace ReadingIsGood.Handler
{
    public static class DbContextHandler
    {
        public static void AddDbContext(this IServiceCollection serviceCollection, string connectionString, string migrationName)
        {
            serviceCollection.AddDbContext<Context.DataContext>(a => a.UseNpgsql(connectionString, b => b.MigrationsAssembly(migrationName)));
        }

        public static void UpdateDatabase(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DataContext>())
                {
                    try
                    {
                        context.Database.Migrate();
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }
    }
}