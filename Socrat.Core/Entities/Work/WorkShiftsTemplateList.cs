using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Core.Entities.Work
{
    [NotMapped]
    public class WorkShiftsTemplateList : Entity
    {
        public WorkShiftsTemplateList()
        {
            WorkShiftsTemplates = new AttachedList<WorkShiftsTemplate>(this);
        }

        public AttachedList<WorkShiftsTemplate> WorkShiftsTemplates { get; }

        [ParentItem]
        public Machines.MachineNom MachineNom{ get; set; }
    }
}
