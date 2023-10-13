using Microsoft.Extensions.Configuration;


namespace WebTests
{
    public class Config
    {
        public static string BaseUrl => GetValue("BaseUrl");
        public static string DriverToUse => GetValue("DriverToUse");

        private static string GetValue(string value)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            return builder.Build()[value];
        }
    }
}
