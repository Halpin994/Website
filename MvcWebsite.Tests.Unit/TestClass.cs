using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcWebsite.Tests.Unit
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            const int result = 2 + 2;
            Assert.AreEqual(result, 4);
        }
    }
}
