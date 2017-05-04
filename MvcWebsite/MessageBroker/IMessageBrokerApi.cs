using System.Collections.Generic;
using MvcWebsite.Models;

namespace MvcWebsite.MessageBroker
{
    public interface IMessageBrokerApi
    {
        IEnumerable<CommentModel> GetPageComments(string pageFilter);
        IEnumerable<CommentModel> GetComments();
        CommentModel GetComment(int id);
        System.Net.HttpStatusCode AddComment(CommentModel comment);
        System.Net.HttpStatusCode UpdateComment(CommentModel comment);
        System.Net.HttpStatusCode DeleteComment(int id);
    }
}
