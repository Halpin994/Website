using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MvcWebsite.Tests.Unit.MockedComponents
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        readonly String _mockedResponse;
        public MockHttpMessageHandler(String mockedResponse)
        {
            _mockedResponse = mockedResponse;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_mockedResponse,Encoding.ASCII,"application/json"),
            };

            return await Task.FromResult(responseMessage);
        }
    }
} 
