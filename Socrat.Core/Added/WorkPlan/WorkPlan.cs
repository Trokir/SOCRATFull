using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Socrat.Core.Added.WorkPlan
{
    [NotMapped]
    public class WorkPlan : Entity
    {
        [NotMapped]
        public List<WorkPlanItem> Items { get; set; } = new List<WorkPlanItem>();
    }
}