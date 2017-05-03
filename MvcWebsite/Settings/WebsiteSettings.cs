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
        public string hostUri { get; private set; }
        public string commentApiPath { get; private set; }

        public WebsiteSettings()
        {
            pageVisitLogPath = ConfigurationManager.AppSettings["PageVisitLogPath"].ToString();
            exceptionLogPath = ConfigurationManager.AppSettings["ExceptionLogPath"].ToString();
            commentLogPath = ConfigurationManager.AppSettings["CommentLogPath"].ToString();
            hostUri = ConfigurationManager.AppSettings["HostUri"].ToString();
            commentApiPath = ConfigurationManager.AppSettings["CommentApiPath"].ToString();
        }
    }
}