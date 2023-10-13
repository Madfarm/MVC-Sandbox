

using SeleniumExtras.PageObjects;

namespace WebTests.PageObjects
{
    
    public class HomePage
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "mynavbar")]
        public IWebElement navBar { get; set; }

    }
}
