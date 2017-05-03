using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using MvcWebsite.Settings;

namespace MvcWebsite.Logger
{
    public class TextLogger : ILogger
    {
        private ISettings settings;

        public TextLogger(ISettings webSiteSettings)
        {
            settings = webSiteSettings;
        }
        public void LogPageVisit(string input)
        {
            using (var streamWriter = new StreamWriter(settings.pageVisitLogPath, true))
            {
                streamWriter.WriteLine(input);
                streamWriter.Close();
            }
        }
        public void LogException(string input)
        {
            using (var streamWriter = new StreamWriter(settings.exceptionLogPath, true))
            {
                streamWriter.WriteLine(input);
                streamWriter.Close();
            }
        }
        public void LogComment(string input)
        {
            using (var streamWriter = new StreamWriter(settings.commentLogPath, true))
            {
                streamWriter.WriteLine(input);
                streamWriter.Close();
            }
        }
    }
}