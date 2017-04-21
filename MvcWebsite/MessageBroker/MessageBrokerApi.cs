using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using MvcWebsite.Models;
using MvcWebsite.Settings;
using System.Threading.Tasks;

namespace MvcWebsite.MessageBroker
{
    //Comment Client class
    public class MessageBrokerApi : IMessageBrokerApi
    {
        private ISettings settings;

        public MessageBrokerApi(ISettings webSiteSettings) //aka CommentClient()
        {
            settings = webSiteSettings;
        }
 
 
        public HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(settings.hostUri), settings.commentApiPath);
            return client;
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
                using (var client = CreateClient())
                {
                    response = client.GetAsync(client.BaseAddress).Result;
                }
                result = response.Content.ReadAsAsync<IEnumerable<CommentModel>>().Result;
            }
            catch(Exception e)
            {
                //Log exception
            }
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