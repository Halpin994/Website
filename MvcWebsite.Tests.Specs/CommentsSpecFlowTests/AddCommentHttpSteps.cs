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
            HttpResponseMessage response;
            using (var client = _httpClientFactory.CreateClient())
            {
                response = client.GetAsync(client.BaseAddress).Result;
            }
            var result = response.Content.ReadAsAsync<IEnumerable<CommentModel>>().Result;

            _actualComments = result.ToList();

            _expectedComment.Id = _actualComments.Last().Id;
        }
        
        [Then(@"the comment I posted is available")]
        public void ThenTheCommentIPostedIsAvailable()
        {
            foreach (var actual in _actualComments)
            {
                if (_actualComments.Any(comment => comment.Id.Equals(_expectedComment.Id)))
                {
                    var actualComment = _actualComments.First(comment => comment.Id.Equals(_expectedComment.Id));
                    Assert.AreEqual(_expectedComment.Comment, actualComment.Comment);
                    Assert.AreEqual(_expectedComment.UserName, actualComment.UserName);
                    Assert.AreEqual(_expectedComment.Webpage, actualComment.Webpage);
                }
            }
        }
    }
}
