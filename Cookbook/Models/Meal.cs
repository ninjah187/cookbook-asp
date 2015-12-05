using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public class Meal : IModelElement
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}