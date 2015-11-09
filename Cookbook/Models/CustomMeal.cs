using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public class CustomMeal : Meal
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}