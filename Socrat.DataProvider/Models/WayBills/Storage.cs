using System;

namespace Socrat.Data.Model
{
    public class Storage : Entity
    {
        public Guid DivisionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual Division Division { get; set; }
        public string Comments { get; set; }
    }
}