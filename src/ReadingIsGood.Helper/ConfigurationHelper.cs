using System;
using Microsoft.Extensions.Configuration;

namespace ReadingIsGood.Helper
{
    public class ConfigurationHelper
    {
        public static IConfigurationRoot Build(string environmentName)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}