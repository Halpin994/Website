
namespace MvcWebsite.Settings
{
    public interface ISettings
    {
        string pageVisitLogPath { get;}
        string exceptionLogPath { get; }
        string commentLogPath { get; }
        string messageBrokerUri { get;}
        string commentApiPath { get; }
    }
}
