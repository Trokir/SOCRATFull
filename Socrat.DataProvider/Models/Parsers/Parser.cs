using System;
using System.Collections.Generic;
using Socrat.Common.Enums;
using Socrat.Core.Added;

namespace Socrat.Data.Model
{
    public class Parser : Entity
    {
        public Guid? DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public string Name { get; set; }
        public string CustomerAlias { get; set; }
        public string Comment { get; set; }
        public Guid? ExtentionId { get; set; }
        public virtual ParseFileExtention Extention { get; set; }
        public bool Default { get; set; }
        public string XMLData { get; set; }
        public ParserType ParserType { get; set; }
        public string DllPath { get; set; }
        public virtual ICollection<CustomerParser> CustomerParsers { get; set; }
    }
}