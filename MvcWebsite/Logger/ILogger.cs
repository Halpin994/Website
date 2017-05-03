using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcWebsite.Settings;

namespace MvcWebsite.Logger
{
    public interface ILogger
    {
        void LogPageVisit(string input);
        void LogException(string input);
        void LogComment(string input);
    }
}
