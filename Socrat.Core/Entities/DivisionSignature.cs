using System;

namespace Socrat.Core.Entities
{
    public class DivisionSignature : Entity
    {
        public Guid? DivisionId { get; set; }
        public Guid? DocumentTypeId { get; set; }
        public Guid? DocumentSignatureTypeId { get; set; }
        public Guid? CoworkerId { get; set; }

        private string _docCoworkerPosition;
        public string DocCoworkerPosition
        {
            get { return _docCoworkerPosition; }
            set { SetField(ref _docCoworkerPosition, value, () => DocCoworkerPosition); }
        }

        private string _docBasics;
        public string DocBasics
        {
            get { return _docBasics; }
            set { SetField(ref _docBasics, value, () => DocBasics); }
        }
        public Guid? CustomerId { get; set; }

        private Coworker _coworker;
        public virtual Coworker Coworker
        {
            get { return _coworker; }
            set { SetField(ref _coworker, value, () => Coworker); }
        }

        private Customer _customer;
        public virtual Customer Customer
        {
            get { return _customer; }
            set { SetField(ref _customer, value, () => Customer); }
        }

        [ParentItem]
        private Division _division;
        public virtual Division Division
        {
            get { return _division; }
            set { SetField(ref _division, value, () => Division); }
        }

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
            return $"Подпись в документе подразделения {Division?.AliasName}";
        }
    }
}
