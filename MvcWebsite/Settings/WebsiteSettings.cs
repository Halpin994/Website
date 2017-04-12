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

        public WebsiteSettings()
        {
            logPath = ConfigurationManager.AppSettings["LogPath"].ToString();
        }
    }
}