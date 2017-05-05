using System.IO;
using MvcWebsite.Settings;

namespace MvcWebsite.Logger
{
    public class TextLogger : ILogger
    {
        private readonly ISettings _settings;

        public TextLogger(ISettings webSiteSettings)
        {
            _settings = webSiteSettings;
        }
        public void LogPageVisit(string input)
        {
            WriteLog(input, _settings.PageVisitLogPath);
        }
        public void LogException(string input)
        {
            WriteLog(input, _settings.ExceptionLogPath);
        }
        public void LogComment(string input)
        {
            WriteLog(input, _settings.CommentLogPath);
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