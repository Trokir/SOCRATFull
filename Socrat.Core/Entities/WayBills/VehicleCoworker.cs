using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Core.Entities.WayBills
{
    public class VehicleCoworker : Entity
    {
        public Guid? VehicleId { get; set; }
        public Guid? CoworkerId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual Coworker Coworker { get; set; }

    }
}
