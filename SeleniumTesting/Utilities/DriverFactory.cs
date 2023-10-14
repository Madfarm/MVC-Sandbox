using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace WebTests.Utilities
{
    public class DriverFactory
    {
        public static IWebDriver _driver;
        public IWebDriver Create()
        {
            string driverToUse = Config.DriverToUse;
            Console.WriteLine(driverToUse);

            switch (driverToUse)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(driverToUse));
            }

            _driver.Manage().Window.Maximize();
            

            return _driver;
        }

        public static IWebDriver GetDriver
        {
            get { return _driver; }
        }
       

        
    }
}
