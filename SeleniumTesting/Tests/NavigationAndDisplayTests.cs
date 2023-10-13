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
        
    }
}
