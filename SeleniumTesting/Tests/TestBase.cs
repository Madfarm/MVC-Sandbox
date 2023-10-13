using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.Utilities;

namespace WebTests.Tests
{
    [SetUpFixture]
    public class TestBase
    {
        protected IWebDriver _driver;
        [OneTimeSetUp]
        public void startUpTest()
        {
            _driver = new DriverFactory().Create();
        }

        [OneTimeTearDown]
        public void endTest()
        {
            _driver.Quit();
        }
    }
}
