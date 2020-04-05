using Socrat.Common.Enums;
using Socrat.Core.Added;

namespace Socrat.Data.Model
{
    public class ParseField : Entity
    {
        public string Name { get; set; }
        public int MaxLength { get; set; }
        public string Description { get; set; }
        public ParseFieldType ParseFieldType { get; set; }
        public int Num { get; set; }
    }
}