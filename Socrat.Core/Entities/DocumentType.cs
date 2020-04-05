using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class DocumentType : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }
        private string _code;
        public string Code
        {
            get { return _code; }
            set { SetField(ref _code, value, () => Code); }
        }
        public virtual ICollection<DivisionSignature> DivisionSignatures { get; set; } = new HashSet<DivisionSignature>();
        public virtual ICollection<DocumentSignature> DocumentSignatures { get; set; } = new HashSet<DocumentSignature>();
        public override string ToString()
        {
            return Name;
        }

        protected override string GetTitle()
        {
            return $"Тип документа: {Name}";
        }
    }
}
