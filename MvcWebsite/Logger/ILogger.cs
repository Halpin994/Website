
using System;

namespace MvcWebsite.Logger
{
    public interface ILogger
    {
        void LogPageVisit(String input);
        void LogException(String exception);
        void LogComment(String input);
    }
}
