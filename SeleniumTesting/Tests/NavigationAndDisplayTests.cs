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
        private readonly HomePage _homePage;
        public NavigationAndDisplayTests(HomePage homepage)
        {
            _homePage = homepage;
        }
        [Test]
        public void NavBarDisplayedShouldPass()
        {
            Assert.That(_homePage.navBar.Displayed, Is.True);
        }
        
    }
}
