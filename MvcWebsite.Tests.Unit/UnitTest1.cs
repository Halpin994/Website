using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvcWebsite.Tests.Unit
{
    [TestClass]
    public class UnitTest1
    {
        int result;

        [TestMethod]
        public void TestMethod1()
        {
            result = 2 + 2;
            Assert.AreEqual(4, result);
        }
    }
}
