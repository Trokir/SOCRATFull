using System;

namespace Socrat.Data.Model
{
    public class CoworkerContact : Entity
    {
        public Guid? CoworkerId { get; set; }
        public Guid? ContactTypeId { get; set; }
        public Guid? TimeRangeId { get; set; }
        public string Value { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual Coworker Coworker { get; set; }
        public virtual TimeRange TimeRange { get; set; }
    }
}