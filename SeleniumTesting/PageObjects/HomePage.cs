

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

        [FindsBy(How= How.Name, Using = "first_name")]
        public IWebElement firstNameField { get; set; }

        [FindsBy(How = How.Name, Using = "last_name")]
        public IWebElement lastNameField { get; set; }

        [FindsBy(How = How.Name, Using = "business_name")]
        public IWebElement businessNameField { get; set; }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement emailField { get; set; }

        [FindsBy(How = How.Id, Using = "demo")]
        public IWebElement SubmitBtn { get; set; }

        



    }
}
