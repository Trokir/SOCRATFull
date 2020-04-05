using System;

namespace Socrat.Data.Model.WayBill
{
    public class VehicleCoworker : Entity
    {
        public Guid? VehicleId { get; set; }
        public Guid? CoworkerId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual Coworker Coworker { get; set; }
    }
}