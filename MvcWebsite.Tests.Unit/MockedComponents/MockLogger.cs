using System;
using MvcWebsite.Logger;

namespace MvcWebsite.Tests.Unit.MockedComponents
{
    public class MockLogger: ILogger
    {
        public String exceptionLogged;

        public void LogPageVisit(String input)
        {
        }

        public void LogException(String exception)
        {
            exceptionLogged = exception;
        }

        public void LogComment(String input)
        {
        }
    }
}