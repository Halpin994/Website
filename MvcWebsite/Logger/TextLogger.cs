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
            WriteLog(input, settings.pageVisitLogPath);
        }
        public void LogException(string input)
        {
            WriteLog(input, settings.exceptionLogPath);
        }
        public void LogComment(string input)
        {
            WriteLog(input, settings.commentLogPath);
        }

        private void WriteLog(string input, string path)
        {
            using (var streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(input);
                streamWriter.Close();
            }
        }
    }
}