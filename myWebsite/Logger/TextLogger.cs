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
        public void Log(string input, ISettings path)
        {
            using (var streamWriter = new StreamWriter(path.logPath, true))
            {
                streamWriter.WriteLine(input);
                streamWriter.Close();
            }
        }
    }
}