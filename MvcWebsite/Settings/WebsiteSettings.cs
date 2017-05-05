using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MvcWebsite.Settings
{
    public class WebsiteSettings : ISettings
    {
        public string PageVisitLogPath { get; private set; }
        public string ExceptionLogPath { get; private set; }
        public string CommentLogPath { get; private set; }
        public string MessageBrokerUri { get; private set; }
        public string CommentApiPath { get; private set; }

        public WebsiteSettings()
        {
            PageVisitLogPath = ConfigurationManager.AppSettings["PageVisitLogPath"];
            ExceptionLogPath = ConfigurationManager.AppSettings["ExceptionLogPath"];
            CommentLogPath = ConfigurationManager.AppSettings["CommentLogPath"];
            MessageBrokerUri = ConfigurationManager.AppSettings["MessageBrokerUri"];
            CommentApiPath = ConfigurationManager.AppSettings["CommentApiPath"];
        }
    }
}