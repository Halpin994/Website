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
        void Log(string input);
    }
}
