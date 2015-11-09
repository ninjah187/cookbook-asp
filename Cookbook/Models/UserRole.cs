using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public enum UserRole : byte
    {
        Admin = 0,
        SuperUser = 1,
        User = 2,
    }
}