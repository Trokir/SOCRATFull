using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Core.Entities.WayBills
{
    public class InternalTransfer : Entity
    {

        [ParentItem]
        public virtual ProductionMovement ProductionMovement { get; set; }        
    }
}
