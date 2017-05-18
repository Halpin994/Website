using System;
using MvcWebsite.Logger;

namespace MvcWebsite.Tests.Specs.MockedComponents
{
    public class MockLogger: ILogger
    {
        public String pageVisitLogged;
        public String exceptionLogged;
        public String commentLogged;

        public void LogPageVisit(String input)
        {
            pageVisitLogged = input;
        }

        public void LogException(String exception)
        {
            exceptionLogged = exception;
        }

        public void LogComment(String input)
        {
            commentLogged = input;
        }
    }
}