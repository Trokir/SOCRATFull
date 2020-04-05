using System;

namespace Socrat.Core.Services
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =true, Inherited =true)]
    public class PropertyPrintTemplateAttribute : Attribute
    {
        public string ParentTemplate { get; private set; }
        public string UseTemplate { get; private set; }
        public PropertyPrintTemplateAttribute(string parentTemplate, string useTemplate)
        {
            ParentTemplate = parentTemplate;
            UseTemplate = useTemplate;
        }
    }
}
