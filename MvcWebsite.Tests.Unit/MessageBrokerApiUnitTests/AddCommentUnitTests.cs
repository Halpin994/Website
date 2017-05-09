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
        [TestCase("Index")]
        public void TestAddCommentIndex(String input)
        {
            String mockedResponse = HttpStatusCode.OK.ToString();
            CommentModel mockedComment = new CommentModel()
            {
                Comment = "testAddComment",
                Id = 1,
                UserName = "testAddUsername",
                Webpage = "Index"
            };
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse));
            System.Net.HttpStatusCode actualResponse = messageBrokerApi.AddComment(mockedComment);
            System.Net.HttpStatusCode expectedResponse = HttpStatusCode.OK;

            AssertCorrectResponse(expectedResponse, actualResponse);
        }

        [Test]
        [TestCase("Projects")]
        public void TestAddCommentProjects(String input)
        {
            String mockedResponse = HttpStatusCode.OK.ToString();
            CommentModel mockedComment = new CommentModel()
            {
                Comment = "testAddComment",
                Id = 1,
                UserName = "testAddUsername",
                Webpage = "Projects"
            };
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse));
            System.Net.HttpStatusCode actualResponse = messageBrokerApi.AddComment(mockedComment);
            System.Net.HttpStatusCode expectedResponse = HttpStatusCode.OK;

            AssertCorrectResponse(expectedResponse, actualResponse);
        }

        [Test]
        [TestCase("ContactMe")]
        public void TestAddCommentContactMe(String input)
        {
            String mockedResponse = HttpStatusCode.OK.ToString();
            CommentModel mockedComment = new CommentModel()
            {
                Comment = "testAddComment",
                Id = 1,
                UserName = "testAddUsername",
                Webpage = "ContactMe"
            };
            var messageBrokerApi = new MessageBrokerApi(new MockLogger(), new MockHttpClientSimpleFactory(mockedResponse));
            System.Net.HttpStatusCode actualResponse = messageBrokerApi.AddComment(mockedComment);
            System.Net.HttpStatusCode expectedResponse = HttpStatusCode.OK;

            AssertCorrectResponse(expectedResponse, actualResponse);
        }
    }
}
