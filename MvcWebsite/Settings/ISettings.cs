
namespace MvcWebsite.Settings
{
    public interface ISettings
    {
        string PageVisitLogPath { get;}
        string ExceptionLogPath { get; }
        string CommentLogPath { get; }
        string MessageBrokerUri { get;}
        string CommentApiPath { get; }
    }
}
