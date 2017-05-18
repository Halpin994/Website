using System;
using MvcWebsite.Settings;

namespace MvcWebsite.Tests.Specs.MockedComponents
{
    public class MockSettings : ISettings
    {
        public string PageVisitLogPath { get; private set; }
        public string ExceptionLogPath { get; private set; }
        public string CommentLogPath { get; private set; }
        public string MessageBrokerUri { get; private set; }
        public string CommentApiPath { get; private set; }

        public MockSettings()
        {
            PageVisitLogPath = "C:/logs/websitelogs.txt";
            ExceptionLogPath = "C:/logs/exceptionlogs.txt";
            CommentLogPath = "C:/logs/commentlogs.txt";
            MessageBrokerUri = "http://localhost:8888";
            CommentApiPath = "api/comments/";
        }
    }
}
