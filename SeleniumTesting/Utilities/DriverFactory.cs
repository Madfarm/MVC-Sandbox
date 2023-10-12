using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace WebTests.Utilities
{
    public enum DriverToUse
    {
        InternetExplorer,
        Chrome,
        Firefox
    }
    public class DriverFactory
    {
        public IWebDriver Create()
        {
            IWebDriver driver;

            var driverToUse = Config.BaseUrl;

            switch(driverToUse)
            {
                case DriverToUse.Chrome:

            }
        }
       

        
    }
}
