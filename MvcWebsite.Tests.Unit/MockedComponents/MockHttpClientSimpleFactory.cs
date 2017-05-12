using System;
using System.Net.Http;
using MvcWebsite.HttpClientFactory;


namespace MvcWebsite.Tests.Unit.MockedComponents
{
    class MockHttpClientSimpleFactory : IHttpClientSimpleFactory
    {
        readonly String _mockResponse;
        readonly System.Net.HttpStatusCode _mockHttpResponse;
        public MockHttpClientSimpleFactory(String mockedResponse, System.Net.HttpStatusCode mockedHttpResponse)
        {
            _mockResponse = mockedResponse;
            _mockHttpResponse = mockedHttpResponse;
        }
        public HttpClient CreateClient()
        {
             var client = new HttpClient(new MockHttpMessageHandler(_mockResponse, _mockHttpResponse))
             {
                 BaseAddress = new Uri(new Uri("http://127.0.0.1"), "testApiPath")

             };
             return client;
        }
    }
}
