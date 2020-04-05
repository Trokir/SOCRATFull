using System;

namespace Socrat.Data.Model
{
    public class DivisionSignature : Entity
    {
        public Guid? DivisionId { get; set; }
        public Guid? DocumentTypeId { get; set; }
        public Guid? DocumentSignatureTypeId { get; set; }
        public Guid? CoworkerId { get; set; }
        public string DocCoworkerPosition { get; set; }
        public string DocBasics { get; set; }
        public Guid? CustomerId { get; set; }
        public virtual Coworker Coworker { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Division Division { get; set; }
        public virtual DocumentSignatureType DocumentSignatureType { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}