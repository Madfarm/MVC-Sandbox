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
        public IWebDriver Create()
        {
            IWebDriver driver;

            string driverToUse = Config.DriverToUse;
            Console.WriteLine(driverToUse);

            switch (driverToUse)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(driverToUse));
            }

            driver.Manage().Window.Maximize();
            

            return driver;
        }
       

        
    }
}
