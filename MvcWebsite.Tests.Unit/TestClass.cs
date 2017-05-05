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
            const int result = 2 + 2;
            Assert.AreEqual(result, 4);
        }

        [Test]
        [TestCase("Index")]
        public void MyTestMethod(String input)
        {
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory());
            var actualComments = messageBrokerApi.GetPageComments("Index").ToList();
 
            var expectedComments = new List<CommentModel>()
            {
                new CommentModel()
                {
                    Comment = "testComment",
                    Id = 1,
                    UserName = "testUsername",
                    Webpage = "Index"
                }
            };
 
            Assert.AreEqual(actualComments.Count, expectedComments.Count);
 
            foreach (var expected in expectedComments)
            {
                if (actualComments.Any(comment => comment.Id.Equals(expected.Id)))
                {
                    var actualComment = actualComments.First(comment => comment.Id.Equals(expected.Id));
                    Assert.AreEqual(expected.Id,actualComment.Id);
                    Assert.AreEqual(expected.Comment,actualComment.Comment);
                    Assert.AreEqual(expected.UserName,actualComment.UserName);
                    Assert.AreEqual(expected.Webpage,actualComment.Webpage);
                }
            }
        }
    }
}
