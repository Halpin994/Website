using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using TechTalk.SpecFlow;
using MvcWebsite.HttpClientFactory;
using MvcWebsite.Models;
using MvcWebsite.Tests.Specs.MockedComponents;
using NUnit.Framework;


namespace MvcWebsite.Tests.Specs.CommentsSpecFlowTests
{
    [Binding]
    public class AddCommentHttpSteps
    {
        private static MockSettings _settings = new MockSettings();
        private HttpClientSimpleFactory _httpClientFactory = new HttpClientSimpleFactory(_settings);
        private List<CommentModel> _actualComments;
        private CommentModel _expectedComment = new CommentModel(){Comment = "SpecTestComment", Id = 0, UserName = "SpecTestUser", Webpage = "SpecTest"};
        private Random R = new Random();
        private int rand;
        [Given(@"I post a comment to the comments controller")]
        public void GivenIPostACommentToTheCommentsController()
        {
            using (var wc = new WebClient())
            {
                rand = R.Next();
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var comment = "Id=0&Webpage=SpecTest" + rand + "&UserName=SpecTestUser&Comment=SpecTestComment";
                var htmlResult = wc.UploadString("http://localhost:8888/api/comments/", comment);
            }
        }
        
        [When(@"I get the comments")]
        public void WhenIGetTheComments()
        {
            HttpResponseMessage response;
            using (var client = _httpClientFactory.CreateClient())
            {
                response = client.GetAsync(client.BaseAddress).Result;
            }
            var result = response.Content.ReadAsAsync<IEnumerable<CommentModel>>().Result;

            _actualComments = result.ToList();

            foreach(var c in _actualComments)
            {
                if (c.Webpage == "SpecTest" + rand)
                _expectedComment.Id = c.Id;
                _expectedComment.Webpage = "SpecTest" + rand;
            }
        }
        
        [Then(@"the comment I posted is available")]
        public void ThenTheCommentIPostedIsAvailable()
        {
            Assert.AreEqual(true, _actualComments.Any(comment => comment.Id.Equals(_expectedComment.Id)));
            var actualComment = _actualComments.First(comment => comment.Id.Equals(_expectedComment.Id));
            Assert.AreEqual(_expectedComment.Comment, actualComment.Comment);
            Assert.AreEqual(_expectedComment.UserName, actualComment.UserName);
            Assert.AreEqual(_expectedComment.Webpage, actualComment.Webpage);
        }
    }
}
