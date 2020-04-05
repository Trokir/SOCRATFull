using Socrat.Data.Model.Machines;
using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class WorkShift : Entity
    {
        public WorkShift()
        {
            WorkQueues = new HashSet<WorkQueue>();
        }

        public Guid? TeamId { get; set; }
        public Guid MachineNomId { get; set; }
        public Guid WorkShiftTypeId { get; set; }
        public DateTime WorkDate { get; set; }
        public int? ShiftDuration { get; set; }
        public virtual Team Team { get; set; }
        public virtual WorkShiftType WorkShiftType { get; set; }
        public virtual MachineNom MachineNom { get; set; }
        public virtual ICollection<WorkQueue> WorkQueues { get; set; }
        public string Title2 { get; set; }
        public int WeekNum { get; set; }
        public int WeekDay { get; set; }
    }
}