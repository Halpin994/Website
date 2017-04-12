using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using MvcWebsite.Models;

namespace MvcWebsite.MessageBroker
{
    public interface IMessageBroker
    {
        HttpClient CreateClient();
        IEnumerable<CommentModel> GetComments();
        CommentModel GetComment(int id);
        System.Net.HttpStatusCode AddComment(CommentModel comment);
        System.Net.HttpStatusCode UpdateComment(CommentModel comment);
        System.Net.HttpStatusCode DeleteComment(int id);
    }
}
