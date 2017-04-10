using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using myWebsite.Settings;

namespace myWebsite.Logger
{
    public class TextLogger : ILogger
    {
        private ISettings settings;

        public TextLogger(ISettings webSiteSettings)
        {
            settings = webSiteSettings;
        }
        public void Log(string input)
        {
            using (var streamWriter = new StreamWriter(settings.logPath, true))
            {
                streamWriter.WriteLine(input);
                streamWriter.Close();
            }
        }
    }
}