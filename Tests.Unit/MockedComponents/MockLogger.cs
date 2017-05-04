using MvcWebsite.Logger;

namespace Tests.Unit.MockedComponents
{
    public class MockLogger : ILogger
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