using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cookbook.Models
{
    public class Product : IModelElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public ItemOrigin Origin { get; set; }
        public float KcalPer100Grams { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}