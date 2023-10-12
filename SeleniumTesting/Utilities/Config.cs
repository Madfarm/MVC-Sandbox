using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTests.Utilities
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
