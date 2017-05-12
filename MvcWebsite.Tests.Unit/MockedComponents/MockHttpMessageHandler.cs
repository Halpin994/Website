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
        private readonly String _mockResponse;
        private readonly MockLogger _logger = new MockLogger();
        readonly System.Net.HttpStatusCode _mockHttpResponse;

        public MockHttpMessageHandler(String mockedResponse, System.Net.HttpStatusCode mockedHttpResponse)
        {
            _mockResponse = mockedResponse;
            _mockHttpResponse = mockedHttpResponse;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage(_mockHttpResponse)
            {
                Content = new StringContent(_mockResponse, Encoding.ASCII, "application/json"),
            };

            return await Task.FromResult(responseMessage);
        }
    }
} 
