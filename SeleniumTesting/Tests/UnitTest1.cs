namespace WebTests.Tests
{
    public class Tests
    {
        //Hooks in NUnit
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            //Browser driver
            IWebDriver webDriver = new ChromeDriver();

            //Navigate to site
            webDriver.Navigate().GoToUrl("https://localhost:7043/");

            //Grab the element
            IWebElement linkCat = webDriver.FindElement(By.LinkText("Cat"));

            //Perform an operation
            linkCat.Click();

            var catPageTable = webDriver.FindElement(By.TagName("table"));

            //Assertion
            Assert.That(catPageTable.Displayed, Is.True);
        }
    }
}