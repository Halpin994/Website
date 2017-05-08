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
        [TestCase("Index")]
        public void TestIndexGetComments(String input)
        {
            String mockedResponse =
                "[" +
                "{" +
                "'Id':'1'," +
                "'Comment':'testComment'," +
                "'Username':'testUsername'," +
                "'Webpage':'Index'," +
                "}," +
                "{" +
                "'Id':'2'," +
                "'Comment':'testComment2'," +
                "'Username':'testUsername2'," +
                "'Webpage':'ContactMe'," +
                "}" +
                "]";
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse));
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
 
            AssertCommentsGot(actualComments, expectedComments);

        }

        [Test]
        [TestCase("Projects")]
        public void TestProjectsGetComments(String input)
        {
            String mockedResponse =
                "[" +
                "{" +
                "'Id':'1'," +
                "'Comment':'testComment'," +
                "'Username':'testUsername'," +
                "'Webpage':'Index'," +
                "}," +
                "{" +
                "'Id':'2'," +
                "'Comment':'testComment2'," +
                "'Username':'testUsername2'," +
                "'Webpage':'ContactMe'," +
                "}," +
                "{" +
                "'Id':'3'," +
                "'Comment':'testComment3'," +
                "'Username':'testUsername3'," +
                "'Webpage':'Projects'," +
                "}" +
                "]";
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse));
            var actualComments = messageBrokerApi.GetPageComments("Projects").ToList();

            var expectedComments = new List<CommentModel>()
            {
                new CommentModel()
                {
                    Comment = "testComment3",
                    Id = 3,
                    UserName = "testUsername3",
                    Webpage = "Projects"
                }
            };

            AssertCommentsGot(actualComments, expectedComments);

        }

        [Test]
        [TestCase("ContactMe")]
        public void TestContactMeGetComments(String input)
        {
            String mockedResponse =
                "[" +
                "{" +
                "'Id':'1'," +
                "'Comment':'testComment'," +
                "'Username':'testUsername'," +
                "'Webpage':'Index'," +
                "}," +
                "{" +
                "'Id':'2'," +
                "'Comment':'testComment2'," +
                "'Username':'testUsername2'," +
                "'Webpage':'ContactMe'," +
                "}," +
                "{" +
                "'Id':'3'," +
                "'Comment':'testComment3'," +
                "'Username':'testUsername3'," +
                "'Webpage':'Projects'," +
                "}" +
                "]";
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse));
            var actualComments = messageBrokerApi.GetPageComments("ContactMe").ToList();

            var expectedComments = new List<CommentModel>()
            {
                new CommentModel()
                {
                    Comment = "testComment2",
                    Id = 2,
                    UserName = "testUsername2",
                    Webpage = "ContactMe"
                }
            };

            AssertCommentsGot(actualComments, expectedComments);

        }

        [Test]
        [TestCase("EmptyResponse")]
        public void TestEmptyResponseComments(String input)
        {
            String mockedResponse =
                "[" +
                "]";
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse));
            var actualComments = messageBrokerApi.GetPageComments("ContactMe").ToList();

            var expectedComments = new List<CommentModel>();

            AssertCommentsGot(actualComments, expectedComments);

        }

        private void AssertCommentsGot(List<CommentModel> actualList, List<CommentModel> expectedList)
        {
            Assert.AreEqual(actualList.Count, expectedList.Count);

            foreach (var expected in expectedList)
            {
                if (actualList.Any(comment => comment.Id.Equals(expected.Id)))
                {
                    var actualComment = actualList.First(comment => comment.Id.Equals(expected.Id));
                    Assert.AreEqual(expected.Id, actualComment.Id);
                    Assert.AreEqual(expected.Comment, actualComment.Comment);
                    Assert.AreEqual(expected.UserName, actualComment.UserName);
                    Assert.AreEqual(expected.Webpage, actualComment.Webpage);
                }
            }
        }
    }
}
