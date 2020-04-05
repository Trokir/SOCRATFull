using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Core.Entities.Work
{
    [NotMapped]
    public class WeeklyWorkShiftsList : Entity
    {
        public WeeklyWorkShiftsList()
        {
            WeeklyWorkShifts = new AttachedList<WeeklyWorkShifts>(this);
        }
        public AttachedList<WeeklyWorkShifts> WeeklyWorkShifts { get; }
    }

    
}
