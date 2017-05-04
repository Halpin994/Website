using System;
using System.Net.Http;
using MvcWebsite.HttpClientFactory;


namespace Tests.Unit.MockedComponents
{
    class MockHttpClientSimpleFactory : IHttpClientSimpleFactory
    {
        public HttpClient CreateClient()
        {
             var client = new HttpClient(new MockHttpMessageHandler())
             {
                 BaseAddress = new Uri(new Uri("http://127.0.0.1"), "testApiPath"),
                 
             };
             return client;
        }
    }
}
