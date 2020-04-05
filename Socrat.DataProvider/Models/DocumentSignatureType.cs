using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class DocumentSignatureType : Entity
    {
        public DocumentSignatureType()
        {
            DivisionSignatures = new HashSet<DivisionSignature>();
            DocumentSignatures = new HashSet<DocumentSignature>();
        }

        public string Name { get; set; }
        public virtual ICollection<DivisionSignature> DivisionSignatures { get; set; }
        public virtual ICollection<DocumentSignature> DocumentSignatures { get; set; }
    }
}