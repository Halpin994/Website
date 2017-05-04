using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MvcWebsite.Tests.Unit.MockedComponents
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
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
                    "'Webpage':'Contact'," +
                    "}" +
                    "]"
                    ,
                    Encoding.ASCII,
                    "application/json"),
            };

            return await Task.FromResult(responseMessage);
        }
    }
} 
