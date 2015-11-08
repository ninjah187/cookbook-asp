using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public class User : IModelElement
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordKey { get; set; }
        public string PasswordSalt { get; set; }
    }
}