using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.Pages;

namespace WebTests.Tests
{
    public class NavTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NavToCatPageCheckForTableToBeDisplayed()
        {
            IWebDriver webDriver = new ChromeDriver();
            HomePage homePage = new(webDriver);

            //Navigate to site
            homePage.Driver.Navigate().GoToUrl("https://localhost:7043/");

            homePage.linkCat.Click();

            Assert.That(homePage.CatHeader.Displayed, Is.True);

        }
    }
}
