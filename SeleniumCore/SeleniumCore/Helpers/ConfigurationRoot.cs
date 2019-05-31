using System;
using Microsoft.Extensions.Configuration;

namespace SeleniumCore.Helpers
{
    internal class ConfigurationRoot
    {
        private static string Environment
        {
            get
            {
                var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE");
                if (string.IsNullOrEmpty(environment))
                {
                    environment = "dev";
                }
                return environment;
            }
        }

        private static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment}.json", optional: true)
                .Build();
        }

        public static AppSettings GetApplicationConfiguration()
        {
            var configuration = new AppSettings();

            var iConfig = GetIConfigurationRoot(AppContext.BaseDirectory);

            iConfig.GetSection("AppSettings").Bind(configuration);

            return configuration;
        }
    }
}
