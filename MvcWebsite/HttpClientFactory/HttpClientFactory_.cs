using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using MvcWebsite.Settings;

namespace MvcWebsite.HttpClientFactory
{
    public class HttpClientFactory_ : IHttpClientFactory_
    {
        private ISettings settings;

        public HttpClientFactory_(ISettings webSiteSettings)
        {
            settings = webSiteSettings;
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(settings.hostUri), settings.commentApiPath);
            return client;
        }
    }
}