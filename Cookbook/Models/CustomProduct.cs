using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public class CustomProduct : Product
    {
        public virtual ICollection<Meal> Meals { get; set; }
    }
}