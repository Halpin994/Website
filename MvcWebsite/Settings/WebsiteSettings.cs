using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MvcWebsite.Settings
{
    public class WebsiteSettings : ISettings
    {
        public string logPath { get; private set; }
        public string hostUri { get; private set; }
        public string commentUri { get; private set; }

        public WebsiteSettings()
        {
            logPath = ConfigurationManager.AppSettings["LogPath"].ToString();
            hostUri = ConfigurationManager.AppSettings["HostUri"].ToString();
            commentApiPath = ConfigurationManager.AppSettings["CommentApiPath"].ToString();
        }
    }
}