using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTests.Utilities;

namespace WebTests.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void startUpTest()
        {
            Browser.Init();
        }

        [TearDown]
        public void endTest()
        {
            Browser.Close();
        }
    }
}
