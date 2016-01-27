using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Web;

namespace Cookbook.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class TranslatedDescriptionAttribute : DescriptionAttribute
    {
        private readonly string _resourceKey;
        private readonly ResourceManager _resourceManager;

        public TranslatedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string displayName = _resourceManager.GetString(_resourceKey);

                return string.IsNullOrEmpty(displayName) ? string.Format("[[{0}]]", _resourceKey) : displayName;
            }
        }
    }
}