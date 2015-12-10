using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Exceptions
{
    public class LoggingException : Exception
    {
        public LoggingException()
        {
        }

        public LoggingException(string message)
            : base(message)
        {
        }
    }
}