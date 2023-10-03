using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTests.Pages
{
    public class HomePage
    {
        public HomePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public IWebDriver Driver { get; set; }
        
        public IWebElement linkCat => Driver.FindElement(By.LinkText("Cat"));

        public void ClickCat() => linkCat.Click();

        public IWebElement linkTable => Driver.FindElement(By.TagName("table"));

        public bool isTableDisplayed => linkTable.Displayed;

        public IWebElement CatHeader => Driver.FindElement(By.TagName("h1"));
    }
}
