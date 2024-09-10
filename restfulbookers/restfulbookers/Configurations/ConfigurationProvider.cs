using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBookerTestFramework.Configurations
{
    public class ConfigurationProvider
    {
        public static TestConfig GetTestConfiguration()
        {
            var configuration = new TestConfig();
            BuildConfiguration().GetSection(nameof(TestConfig)).Bind(configuration);
            return configuration;
        }

        private static IConfiguration BuildConfiguration()
        {
            // Ładowanie konfiguracji z pliku appsettings.json
            var _configurationBuilder = new ConfigurationBuilder();
            return _configurationBuilder
                .SetBasePath(AppContext.BaseDirectory)  // Ścieżka bazowa (do katalogu aplikacji)
                .AddJsonFile("Configurations/appconfig.json", optional: false, reloadOnChange: true)  // Ładowanie pliku JSON
                .Build();
        }
    }
}
