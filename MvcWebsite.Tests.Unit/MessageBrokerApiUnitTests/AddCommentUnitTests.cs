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
        private void AssertCorrectResponse(System.Net.HttpStatusCode expected, System.Net.HttpStatusCode actual)
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
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
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
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
            System.Net.HttpStatusCode actualResponse = messageBrokerApi.AddComment(mockedComment);
            System.Net.HttpStatusCode expectedResponse = HttpStatusCode.OK;

            AssertCorrectResponse(expectedResponse, actualResponse);
        }

        [Test]
        public void TestAddCommentEmpty()
        {
            String mockedResponse = "";
            System.Net.HttpStatusCode mockedHttpResponse = HttpStatusCode.BadRequest;
            CommentModel mockedComment = new CommentModel()
            {
                Comment = "",
                Id = 1,
                UserName = "",
                Webpage = ""
            };
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse, mockedHttpResponse));
            System.Net.HttpStatusCode actualResponse = messageBrokerApi.AddComment(mockedComment);
            System.Net.HttpStatusCode expectedResponse = HttpStatusCode.OK;

            AssertCorrectResponse(expectedResponse, actualResponse);
        }
    }
}
