using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public class BasicProduct : Product
    {
        public virtual ICollection<Meal> Meals { get; set; }
    }
}