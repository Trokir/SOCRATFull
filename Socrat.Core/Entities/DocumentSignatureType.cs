using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class DocumentSignatureType : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }
        public virtual ICollection<DivisionSignature> DivisionSignatures { get; set; } = new HashSet<DivisionSignature>();
        public virtual ICollection<DocumentSignature> DocumentSignatures { get; set; } = new HashSet<DocumentSignature>();

        protected override string GetTitle()
        {
            return $"Тип подписи: " + Name;
        }
    }
}
