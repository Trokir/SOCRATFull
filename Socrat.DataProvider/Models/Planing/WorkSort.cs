using System;

namespace Socrat.Data.Model
{
    public class WorkSort : Entity
    {
        public Guid? WorkSortTypeId { get; set; }
        public bool? WorSortDesc { get; set; }
        public string WorkSortPosition { get; set; }
        public string WorkSortDescription { get; set; }
        public int WorkSortNumber { get; set; }

        public virtual WorkSortType WorkSortType { get; set; }
    }
}