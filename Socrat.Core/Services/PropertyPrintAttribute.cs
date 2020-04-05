using System;

namespace Socrat.Core.Services
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =false, Inherited =true)]
    public class PropertyPrintAttribute : Attribute
    {
        public string Format { get; private set; }

        public PropertyPrintAttribute(string format)
        {
            Format = format;
        }
    }
}
