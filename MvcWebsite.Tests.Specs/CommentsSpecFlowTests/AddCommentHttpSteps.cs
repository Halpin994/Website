using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TechTalk.SpecFlow;
using MvcWebsite.MessageBroker;
using MvcWebsite.HttpClientFactory;
using MvcWebsite.Models;
using MvcWebsite.Tests.Specs.MockedComponents;
using NUnit.Framework;

namespace MvcWebsite.Tests.Specs.CommentsSpecFlowTests
{
    [Binding]
    public class AddCommentHttpSteps
    {
        private readonly MockSettings _settings = new MockSettings();
        private readonly MockLogger _mockLogger = new MockLogger();
        private readonly MessageBrokerApi _messageBroker;
        private List<CommentModel> _actualComments;
        private CommentModel expectedComment;

        AddCommentHttpSteps()
        {
            var httpClientSimpleFactory = new HttpClientSimpleFactory(_settings);
            _messageBroker = new MessageBrokerApi(_mockLogger, httpClientSimpleFactory);
            expectedComment = new CommentModel(){Comment = "SpecTestComment", Id = 500, UserName = "SpecTestUser", Webpage = "SpecTest"};
        }

        [Given(@"I post a comment to the comments controller")]
        public void GivenIPostACommentToTheCommentsController()
        {
            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var htmlResult = wc.UploadString("http://localhost:8888/api/comments/", "Id=0&Webpage=SpecTest&UserName=SpecTestUser&Comment=SpecTestComment");
            }
        }
        
        [When(@"I get the comments")]
        public void WhenIGetTheComments()
        {
            _actualComments = _messageBroker.GetComments().ToList();
        }
        
        [Then(@"the comment I posted is available")]
        public void ThenTheCommentIPostedIsAvailable()
        {
            foreach (var actual in _actualComments)
            {
                if (_actualComments.Any(comment => comment.Webpage.Equals("SpecTest")))
                {
                    var actualComment = _actualComments.Last(comment => comment.Webpage.Equals("SpecTest"));
                    Assert.AreEqual(expectedComment.Comment, actualComment.Comment);
                    Assert.AreEqual(expectedComment.UserName, actualComment.UserName);
                    Assert.AreEqual(expectedComment.Webpage, actualComment.Webpage);
                }
            }
        }
    }
}
