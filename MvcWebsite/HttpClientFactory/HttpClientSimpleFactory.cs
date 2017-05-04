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
        private readonly ISettings _settings;

        public HttpClientSimpleFactory(ISettings webSiteSettings)
        {
            _settings = webSiteSettings;
        }

        public HttpClient CreateClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(new Uri(_settings.messageBrokerUri), _settings.commentApiPath)
            };
            return client;
        }
    }
}