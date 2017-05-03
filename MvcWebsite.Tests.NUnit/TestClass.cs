using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWebsite.Tests.NUnit
{
    [TestFixture]
    public class TestClass
    {
        int result;

        [Test]
        public void TestMethod()
        {
            result = 2 + 2;
            Assert.AreEqual(result, 4);
        }
    }
}
