using MvcWebsite.Logger;

namespace MvcWebsite.Tests.Unit.MockedComponents
{
    internal class MockLogger : ILogger
    {
        public void LogPageVisit(string input)
        {
        }

        public void LogException(string input)
        {
        }

        public void LogComment(string input)
        {
        }
    }
}