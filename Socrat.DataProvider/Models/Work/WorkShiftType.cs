using System;
using System.Collections.Generic;
using System.Drawing;

namespace Socrat.Data.Model
{
    public class WorkShiftType : Entity
    {
        public WorkShiftType()
        {
            WorkShifts = new HashSet<WorkShift>();
            WorkShiftWeeks = new HashSet<WorkShiftsTemplate>();
        }

        public Guid DivisionId { get; set; }
        public string Name { get; set; }
        public int? OrderNum { get; set; }
        public Color? Color { get; set; }
        public int? ColorRGB { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<WorkShift> WorkShifts { get; set; }
        public virtual ICollection<WorkShiftsTemplate> WorkShiftWeeks { get; set; }
        public string AliasName { get; set; }
    }
}