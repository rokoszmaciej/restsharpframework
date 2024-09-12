using Microsoft.Extensions.Configuration;
using restfulbookers.Models.Booking;


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

        public static BookingModel GetBookingData()
        {
            var booking = new BookingModel();
            BuildConfiguration().GetSection("TestBooking").Bind(booking);
            return booking;
        }

        private static IConfiguration BuildConfiguration()
        {
            // Ładowanie konfiguracji z pliku appsettings.json
            var _configurationBuilder = new ConfigurationBuilder();
            return _configurationBuilder
                .SetBasePath(AppContext.BaseDirectory)  // Ścieżka bazowa (do katalogu aplikacji)
                .AddJsonFile("Configurations/appconfig.json", optional: false, reloadOnChange: true)  // Ładowanie pliku JSON
                .AddJsonFile("Configurations/testdata.json", optional: false, reloadOnChange: true)  // Ładowanie pliku JSON
                .Build();
        }
    }
}
