﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace myWebsite.Settings
{
    public class WebsiteSettings : ISettings
    {


        string logPath { public get; private set; }

        public WebsiteSettings()
        {
            logPath = ConfigurationManager.AppSettings["LogPath"].ToString();
        }
        
    }
}