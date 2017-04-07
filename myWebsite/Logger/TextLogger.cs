using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace myWebsite.Logger
{
    public class TextLogger : ILogger
    {
        string path = @"C:\logs\websitelogs.txt";
        public void Log(string input)
        {
            File.WriteAllText(path, input);
        }
    }
}