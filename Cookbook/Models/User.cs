﻿using System;
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
        public UserRole Role { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}