using System.Collections.Generic;

namespace Socrat.Data.Model.Planing
{
    public class WorkSortField : Entity
    {
        public string WSortField { get; set; }
        public string WSortName { get; set; }
        public ICollection<WorkSort> WorkSorts { get; set; }
    }
}