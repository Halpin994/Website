using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using MvcWebsite.MessageBroker;
using MvcWebsite.Models;
using MvcWebsite.Tests.Unit.MockedComponents;

namespace MvcWebsite.Tests.Unit
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            int result;
            result = 2 + 2;
            Assert.AreEqual(result, 4);
        }
    }
}
