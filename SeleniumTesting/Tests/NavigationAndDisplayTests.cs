using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.PageObjects;

namespace WebTests.Tests
{
    [TestFixture]
    public class NavigationAndDisplayTests : TestBase
    {
        [Test]
        public void NavBarDisplayedShouldPass()
        {
            var homePage = new HomePage(_driver);

            Assert.That(homePage.navBar.Displayed, Is.True);
        }

        [Test]
        public void ContactFormTestFlowShouldPass()
        {
            var homePage = new HomePage(_driver);

            homePage.firstNameField.SendKeys("Meguy");
            homePage.lastNameField.SendKeys("ActualLastname");
            homePage.emailField.SendKeys("email@example.com");
            homePage.businessNameField.SendKeys("MyBusiness");
            homePage.SubmitBtn.Click();
        }

        [Test]
        public void CheckValidationOfEmptyContactForm()
        {
            var homePage = new HomePage(_driver);

            homePage.SubmitBtn.Click();

            //var alertText = _driver.SwitchTo().Alert();
        }
        
    }
}
