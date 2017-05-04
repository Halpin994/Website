
namespace MvcWebsite.Logger
{
    public interface ILogger
    {
        void LogPageVisit(string input);
        void LogException(string input);
        void LogComment(string input);
    }
}
