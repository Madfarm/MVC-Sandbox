using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.Reporting;
using WebTests.Utilities;

namespace WebTests.Tests
{
    [SetUpFixture]
    public class TestBase
    {
        protected IWebDriver _driver;
        protected static ReportsManager Reports;
        [OneTimeSetUp]
        public void startUpTest()
        {
            _driver = new DriverFactory().Create();

            // Reporting to be implemented later
            //Reports = new ReportsManager(Config.DriverToUse, Config.BaseUrl);

            _driver.Navigate().GoToUrl(Config.BaseUrl);
        }

        [OneTimeTearDown]
        public void endTest()
        {
            _driver.Quit();
        }
    }
}
