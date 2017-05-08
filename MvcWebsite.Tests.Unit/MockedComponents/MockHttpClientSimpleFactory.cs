using System;
using System.Net.Http;
using MvcWebsite.HttpClientFactory;


namespace MvcWebsite.Tests.Unit.MockedComponents
{
    class MockHttpClientSimpleFactory : IHttpClientSimpleFactory
    {
        readonly String _mockResponse;
        public MockHttpClientSimpleFactory(String mockedResponse)
        {
            _mockResponse = mockedResponse;
        }

        public HttpClient CreateClient()
        {
             var client = new HttpClient(new MockHttpMessageHandler(_mockResponse))
             {
                 BaseAddress = new Uri(new Uri("http://127.0.0.1"), "testApiPath")

             };
             return client;
        }
    }
}
