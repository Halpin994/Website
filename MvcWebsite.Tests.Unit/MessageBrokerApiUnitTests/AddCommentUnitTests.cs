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
    public class AddCommentUnitTests
    {
        private MockLogger logger = new MockLogger();

        private void AssertCorrectResponse(System.Net.HttpStatusCode expected, System.Net.HttpStatusCode actual)
        {
            Assert.AreEqual(expected, actual);
        }
        private void AssertCorrectException(String expected, String actual)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddComment()
        {
            String mockedResponse = "";
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.OK;
            CommentModel mockedComment = new CommentModel()
            {
                Comment = "testAddComment",
                Id = 1,
                UserName = "testAddUsername",
                Webpage = "Index"
            };
            var messageBrokerApi = new MessageBrokerApi(logger, new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
            System.Net.HttpStatusCode actualResponse = messageBrokerApi.AddComment(mockedComment);
            System.Net.HttpStatusCode expectedResponse = HttpStatusCode.OK;

            AssertCorrectResponse(expectedResponse, actualResponse);
        }

        [Test]
        public void TestAddCommentNull()
        {
            String mockedResponse = "";
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.OK;
            CommentModel mockedComment = new CommentModel()
            {
                Comment = null,
                Id = 1,
                UserName = null,
                Webpage = null
            };
            var messageBrokerApi = new MessageBrokerApi(logger, new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
            System.Net.HttpStatusCode actualResponse = messageBrokerApi.AddComment(mockedComment);
            System.Net.HttpStatusCode expectedResponse = HttpStatusCode.OK;

            AssertCorrectResponse(expectedResponse, actualResponse);
        }

        [Test]
        public void TestAddCommentNoResponse()
        {
            String mockedResponse = "";
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.NotFound;
            CommentModel mockedComment = new CommentModel()
            {
                Comment = "test",
                Id = 1,
                UserName = "test",
                Webpage = "test"
            };
            var messageBrokerApi = new MessageBrokerApi(logger, new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
            System.Net.HttpStatusCode actualResponse = messageBrokerApi.AddComment(mockedComment);
            System.Net.HttpStatusCode expectedResponse = HttpStatusCode.NotFound;

            AssertCorrectResponse(expectedResponse, actualResponse);
        }

        [Test]
        public void TestAddCommentNoBrokerException()
        {
            String mockedResponse = null;
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.NotFound;
            CommentModel mockedComment = new CommentModel()
            {
                Comment = "test",
                Id = 1,
                UserName = "test",
                Webpage = "test"
            };
            var messageBrokerApi = new MessageBrokerApi(logger, new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
            messageBrokerApi.AddComment(mockedComment);
            Assert.AreNotEqual(logger.exceptionLogged, null);
        }
    }
}
