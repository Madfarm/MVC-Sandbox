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

            var driverToUse = Config.DriverToUse;

            switch(driverToUse)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentException();

            }

            driver.Manage().Window.Maximize();


            return driver;
        }
       

        
    }
}
