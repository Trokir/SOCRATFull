using System;

namespace Socrat.Data.Model
{
    public class CustomerMaterialNomEquivalent : Entity
    {
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string NomCode { get; set; }
        public Guid? MaterialNomId { get; set; }
        public virtual MaterialNom MaterialNom { get; set; }
    }
}