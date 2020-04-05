using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Waybill : Entity
    {
        public Waybill()
        {
            Rows = new HashSet<WaybillRow>();
        }

        public Guid CustomerId { get; set; }
        public Guid ConsigneeId { get; set; }
        public Guid StorageId { get; set; }
        public Guid DeliveryAddressId { get; set; }
        public Guid CustomerCoworkerId { get; set; }
        public Guid VehicleId { get; set; }

        public ICollection<WaybillRow> Rows { get; set; }

        public DateTime Dated { get; set; }
        public int Number { get; set; }
        public bool IsManagementAccounted { get; set; }
        public string Comments { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Customer Consignee { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual CustomerAddress DeliveryAddress { get; set; }
        public virtual CustomerCoworker CustomerCoworker { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}