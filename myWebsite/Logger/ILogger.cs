using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myWebsite.Settings;

namespace myWebsite.Logger
{
    public interface ILogger
    {
        void Log(string input);
    }
}
