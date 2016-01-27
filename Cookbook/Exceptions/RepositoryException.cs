using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException()
        {
        }

        public RepositoryException(string message)
            : base(message)
        {
        }
    }
}