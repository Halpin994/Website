using NUnit.Framework;
using TechTalk.SpecFlow;
using MvcWebsite.MessageBroker;
using MvcWebsite.Logger;
using MvcWebsite.Settings;
using MvcWebsite.HttpClientFactory;
using MvcWebsite.Models;
using MvcWebsite.Controllers;

namespace MvcWebsite.Tests.Specs
{
    [Binding]
    public class AddCommentSteps
    {
        private IMessageBrokerApi _messageBroker;
        private CommentController _commentController;
        private CommentModel comment;

        public AddCommentSteps()
        {
            var settings = new WebsiteSettings();
            var textLogger = new TextLogger(settings);
            var httpClientSimpleFactory = new HttpClientSimpleFactory(settings);
            _messageBroker = new MessageBrokerApi(textLogger, httpClientSimpleFactory);
            _commentController = new CommentController(textLogger, _messageBroker);
            comment = new CommentModel();
        }
        [Given(@"a comment")]
        public void GivenAComment()
        {
            comment.Id = 1;
            comment.Webpage = "Index";
            comment.UserName = "SpecTestUser";
            comment.Comment = "SpecTestComment";
        }
        
        [When(@"the request is posted to the comments controller")]
        public void WhenTheRequestIsPostedToTheCommentsController()
        {
            _commentController.CreateComment(comment);
        }
        
        [Then(@"the new comment is available in the message broker via GetComment")]
        public void ThenTheNewCommentIsAvailableInTheMessageBrokerViaGetComment()
        {
            
            Assert.AreEqual(_messageBroker.GetComments(), comment);
        }
    }
}
