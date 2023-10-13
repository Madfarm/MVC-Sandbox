using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.Utilities;

namespace WebTests.Tests
{
    [TestFixture]
    public class TestBase
    {
        [OneTimeSetUp]
        public void startUpTest()
        {
            Browser.Init();
        }

        [OneTimeTearDown]
        public void endTest()
        {
            Browser.Close();
        }
    }
}
