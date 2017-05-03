using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using MvcWebsite.Settings;

namespace MvcWebsite.HttpClientFactory
{
    public class HttpClientSimpleFactory : IHttpClientSimpleFactory
    {
        private ISettings settings;

        public HttpClientSimpleFactory(ISettings webSiteSettings)
        {
            settings = webSiteSettings;
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(settings.messageBrokerUri), settings.commentApiPath);
            return client;
        }
    }
}