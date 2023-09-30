namespace WebTests
{
    public class Tests
    {
        //Hooks in NUnit
        [SetUp]
        public void Setup()
        {
            //Browser driver
            IWebDriver webDriver = new ChromeDriver();

            //Navigate to site
            webDriver.Navigate().GoToUrl("https://localhost:7043/");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}