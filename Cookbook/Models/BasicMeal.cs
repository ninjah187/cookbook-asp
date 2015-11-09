using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public class BasicMeal : Meal
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}