using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Logger.Manager
{
    public class LoggerException : Exception
    {
        public LoggerException(string message, Exception e) : base(message, e) { }

        public LoggerException(string message) : base(message) { }
    }
}
