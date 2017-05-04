using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Net.Http;
using MvcWebsite.Models;
using MvcWebsite.Logger;
using MvcWebsite.HttpClientFactory;


namespace MvcWebsite.MessageBroker
{
    public class MessageBrokerApi : IMessageBrokerApi
    {
        private readonly IHttpClientSimpleFactory _httpClientFactory;
        private readonly ILogger _logger;

        public MessageBrokerApi(ILogger logger, IHttpClientSimpleFactory httpClient)
        {
            _httpClientFactory = httpClient;
            _logger = logger;
        }
 
        public IEnumerable<CommentModel> GetPageComments(string pageFilter)
        {
            return GetComments().Where(comment => comment.Webpage.Equals(pageFilter));
        }

        public IEnumerable<CommentModel> GetComments()
        {
            IEnumerable<CommentModel> result = new List<CommentModel>();
            try
            {
                HttpResponseMessage response;
                using (var client = _httpClientFactory.CreateClient())
                {
                    response = client.GetAsync(client.BaseAddress).Result;
                }
                result = response.Content.ReadAsAsync<IEnumerable<CommentModel>>().Result;
            }
            catch(Exception exception)
            {
                _logger.LogException(String.Format("Time={0}, Exception={1}.", DateTime.Now, exception));
            }
            return result;
        }
 
 
        public CommentModel GetComment(int id)
        {
            HttpResponseMessage response;
            using (var client = _httpClientFactory.CreateClient())
            {
                response = client.GetAsync(
                    new Uri(client.BaseAddress, id.ToString())).Result;
            }
            var result = response.Content.ReadAsAsync<CommentModel>().Result;
            return result;
        }


        public System.Net.HttpStatusCode AddComment(CommentModel comment)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (var client = _httpClientFactory.CreateClient())
                {
                    response = client.PostAsJsonAsync(client.BaseAddress.ToString(), comment).Result;
                }
            }
            catch (Exception exception)
            {
                _logger.LogException(String.Format("Time={0}, Exception={1}.", DateTime.Now, exception));
            }
            return response.StatusCode;
        }


        public System.Net.HttpStatusCode UpdateComment(CommentModel comment)
        {
            HttpResponseMessage response;
            using (var client = _httpClientFactory.CreateClient())
            {
                response = client.PutAsJsonAsync(client.BaseAddress.ToString(), comment).Result;
            }
            return response.StatusCode;
        }
 
 
        public System.Net.HttpStatusCode DeleteComment(int id)
        {
            HttpResponseMessage response;
            using (var client = _httpClientFactory.CreateClient())
            {
                response = client.DeleteAsync(new Uri(client.BaseAddress, id.ToString(CultureInfo.InvariantCulture))).Result;
            }
            return response.StatusCode;
        }
    }
}