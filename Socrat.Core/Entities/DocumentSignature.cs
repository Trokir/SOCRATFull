using System;

namespace Socrat.Core.Entities
{
    public class DocumentSignature : Entity
    {
        public Guid? DocumentTypeId { get; set; }
        public Guid? DocumentSignatureTypeId { get; set; }
        private DocumentSignatureType _documentSignatureType;
        public virtual DocumentSignatureType DocumentSignatureType
        {
            get { return _documentSignatureType; }
            set { SetField(ref _documentSignatureType, value, () => DocumentSignatureType); }
        }


        private DocumentType _documentType;
        public virtual DocumentType DocumentType
        {
            get { return _documentType; }
            set { SetField(ref _documentType, value, () => DocumentType); }
        }

        protected override string GetTitle()
        {
            return "Подпись в документе";
        }
    }
}
