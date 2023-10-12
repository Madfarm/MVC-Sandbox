using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTests.Utilities
{
    public class Browser
    {
        private static IWebDriver driver;
        private static DriverFactory _driverFactory;

        public Browser()
        {
            _driverFactory = new DriverFactory();
        }
        public static void Init()
        {
            driver = _driverFactory.Create();
            Goto(Config.BaseUrl);
        }

        public static string Title
        {
            get { return driver.Title; }
        }

        public static IWebDriver getDriver
        {
            get { return driver;  }
        }
        public static void Goto(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void Close()
        {
            driver.Quit();
        }
    }
}
