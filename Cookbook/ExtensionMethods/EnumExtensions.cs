using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Cookbook.Attributes;

namespace Cookbook.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static string GetTranslatedDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes =
                (TranslatedDescriptionAttribute[]) 
                    fieldInfo.GetCustomAttributes(typeof (TranslatedDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}