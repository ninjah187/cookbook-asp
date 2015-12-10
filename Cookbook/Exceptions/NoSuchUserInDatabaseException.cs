using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Exceptions
{
    public class NoSuchUserInDatabaseException : LoggingException
    {
        public NoSuchUserInDatabaseException(string userLogin)
            : base("No user " + userLogin)
        {
        }
    }
}