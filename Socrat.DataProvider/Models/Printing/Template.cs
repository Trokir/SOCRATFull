using System;

namespace Socrat.Data.Model
{
    public class Template : Entity
    {
        public Guid? DivisionId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? TemplateFormatId { get; set; }
        public string Name { get; set; }
        public string BuiltInReportClassName { get; set; }
        public string EntityClassName { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Division Division { get; set; }
        public virtual TemplateFormat TemplateFormat { get; set; }
        public bool IsDefault { get; set; }
        public string Contents { get; set; }
        public string Comments { get; set; }
    }
}