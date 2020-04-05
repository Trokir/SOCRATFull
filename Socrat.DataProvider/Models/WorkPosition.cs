using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class WorkPosition : Entity
    {
        public WorkPosition()
        {
            AddressContacts = new HashSet<AddressContact>();
            CoworkerPositions = new HashSet<CoworkerPosition>();
        }

        public string Name { get; set; }
        public virtual ICollection<AddressContact> AddressContacts { get; set; }
        public virtual ICollection<CoworkerPosition> CoworkerPositions { get; set; }
    }
}