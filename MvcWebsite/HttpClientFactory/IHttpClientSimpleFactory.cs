using System.Net.Http;

namespace MvcWebsite.HttpClientFactory
{
    public interface IHttpClientSimpleFactory
    {
        HttpClient CreateClient();
    }
}
