using System;
using System.Collections.Generic;
using Socrat.Common.Enums;
using Socrat.Data.Model.Machines;

namespace Socrat.Data.Model
{
    public class WorkQueue : Entity
    {
        public WorkQueue()
        {
            Orders = new HashSet<Order>();
        }

        public virtual WorkSortType WorkSortType { get; set; }
        public DateTime WorkDate { get; set; }
        public Guid DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public Guid? WorkQueueAssignmentId { get; set; }
        public virtual WorkQueueAssignment WorkQueueAssignment { get; set; }
        public Guid? MachineNomId { get; set; }
        public Guid? WorkSortTypeId { get; set; }
        public virtual MachineNom MachineNom { get; set; }
        public Guid? WorkShiftId { get; set; }
        public virtual WorkShift WorkShift { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public PiramideType PiramideType { get; set; }
    }
}