using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWebsite.Settings
{
    public interface ISettings
    {
        string pageVisitLogPath { get;}
        string exceptionLogPath { get; }
        string commentLogPath { get; }
        string hostUri { get;}
        string commentApiPath { get; }
    }
}
