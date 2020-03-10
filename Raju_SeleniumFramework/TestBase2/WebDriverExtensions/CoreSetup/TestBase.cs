using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBase2.WebDriverExtensions.CoreSetup
{
    [TestFixture]
    public class TestBase
    {
      //  [TestFixture]
        public void OneTimeSetupForTests()
        {

        }

        [SetUp]
        public void LogOn()
        {

        }

        [TearDown]
        public void LogOff()
        {

        }
    }
}
