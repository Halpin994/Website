using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using MvcWebsite.Models;

namespace MvcWebsite.MessageBroker
{
    public class MessageBrokerApi : IMessageBroker
    {
        string _hostUri;
        public MessageBrokerApi(string hostUri)
        {
            _hostUri = hostUri;
        }
 
 
        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/comments/");
            return client;
        }
 
 
        public IEnumerable<CommentModel> GetComments()
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.GetAsync(client.BaseAddress).Result;
            }
            var result = response.Content.ReadAsAsync<IEnumerable<CommentModel>>().Result;
            return result;
        }
 
 
        public CommentModel GetComment(int id)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.GetAsync(
                    new Uri(client.BaseAddress, id.ToString())).Result;
            }
            var result = response.Content.ReadAsAsync<CommentModel>().Result;
            return result;
        }


        public System.Net.HttpStatusCode AddComment(CommentModel comment)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.PostAsJsonAsync(client.BaseAddress, comment).Result;
            }
            return response.StatusCode;
        }


        public System.Net.HttpStatusCode UpdateComment(CommentModel comment)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.PutAsJsonAsync(client.BaseAddress, comment).Result;
            }
            return response.StatusCode;
        }
 
 
        public System.Net.HttpStatusCode DeleteComment(int id)
        {
            HttpResponseMessage response;
            using (var client = CreateClient())
            {
                response = client.DeleteAsync(
                    new Uri(client.BaseAddress, id.ToString())).Result;
            }
            return response.StatusCode;
        }
    }
}