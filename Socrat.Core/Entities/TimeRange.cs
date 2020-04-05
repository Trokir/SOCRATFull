using System;
using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class TimeRange : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan? StartRange { get; set; }
        public TimeSpan? EndRange { get; set; }
        public int? Days { get; set; }
        public virtual ICollection<CoworkerContact> CoworkerContacts { get; set; } = new HashSet<CoworkerContact>();
    }
}
