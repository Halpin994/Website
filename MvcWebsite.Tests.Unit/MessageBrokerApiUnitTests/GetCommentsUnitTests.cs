using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using MvcWebsite.MessageBroker;
using MvcWebsite.Models;
using MvcWebsite.Tests.Unit.MockedComponents;

namespace MvcWebsite.Tests.Unit.MessageBrokerApiUnitTests
{

    [TestFixture]
    public class GetCommentsUnitTests
    {
        private MockLogger logger = new MockLogger();

        private void AssertCommentCollectionsEqual(List<CommentModel> expectedList, List<CommentModel> actualList)
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

        [Test]
        public void TestGetCommentsIndex()
        {
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.OK;
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
            var messageBrokerApi = new MessageBrokerApi(logger, new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
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

            AssertCommentCollectionsEqual(expectedComments, actualComments);
        }

        [Test]
        public void TestGetCommentsProjects()
        {
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.OK;
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
            var messageBrokerApi = new MessageBrokerApi(logger, new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
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

            AssertCommentCollectionsEqual(expectedComments, actualComments);
        }

        [Test]
        public void TestGetCommentsContactMe()
        {
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.OK;
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
            var messageBrokerApi = new MessageBrokerApi(logger, new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
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

            AssertCommentCollectionsEqual(expectedComments, actualComments);
        }

        [Test]
        public void TestGetCommentsEmptyResponse()
        {
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.OK;
            String mockedResponse =
                "[" +
                "]";
            var messageBrokerApi = new MessageBrokerApi(logger, new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
            var actualComments = messageBrokerApi.GetPageComments("ContactMe").ToList();

            var expectedComments = new List<CommentModel>();

            AssertCommentCollectionsEqual(expectedComments, actualComments);
        }

        [Test]
        public void TestGetCommentsNoBrokerException()
        {
            String mockedResponse = null;
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.NotFound;

            var messageBrokerApi = new MessageBrokerApi(logger, new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
            messageBrokerApi.GetComments();
            Assert.AreNotEqual(logger.exceptionLogged, null);
        }
    }
}
