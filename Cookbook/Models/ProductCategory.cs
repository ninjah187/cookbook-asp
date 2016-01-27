using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cookbook.Attributes;
using Cookbook.TranslationResources;

namespace Cookbook.Models
{
    public enum ProductCategory : byte
    {
        [TranslatedDescription("Vegetable", typeof(TranslatedProductCategoriesPL))]
        Vegetable = 0,

        [TranslatedDescription("Meat", typeof(TranslatedProductCategoriesPL))]
        Meat = 1,

        [TranslatedDescription("Fruit", typeof(TranslatedProductCategoriesPL))]
        Fruit = 2,

        [TranslatedDescription("Bread", typeof(TranslatedProductCategoriesPL))]
        Bread = 3,

        [TranslatedDescription("Dairy", typeof(TranslatedProductCategoriesPL))]
        Dairy = 4,
    }
}