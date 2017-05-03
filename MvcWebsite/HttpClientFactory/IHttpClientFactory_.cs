using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

namespace MvcWebsite.HttpClientFactory
{
    public interface IHttpClientFactory_
    {
        HttpClient CreateClient();
    }
}
