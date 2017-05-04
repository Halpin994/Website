using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MvcWebsite.Settings
{
    public class WebsiteSettings : ISettings
    {
        public string pageVisitLogPath { get; private set; }
        public string exceptionLogPath { get; private set; }
        public string commentLogPath { get; private set; }
        public string messageBrokerUri { get; private set; }
        public string commentApiPath { get; private set; }

        public WebsiteSettings()
        {
            pageVisitLogPath = ConfigurationManager.AppSettings["PageVisitLogPath"];
            exceptionLogPath = ConfigurationManager.AppSettings["ExceptionLogPath"];
            commentLogPath = ConfigurationManager.AppSettings["CommentLogPath"];
            messageBrokerUri = ConfigurationManager.AppSettings["MessageBrokerUri"];
            commentApiPath = ConfigurationManager.AppSettings["CommentApiPath"];
        }
    }
}