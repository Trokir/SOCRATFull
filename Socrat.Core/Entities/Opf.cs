using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class Opf : Entity
    {
        private string _alias;
        public string Alias
        {
            get { return _alias; }
            set { SetField(ref _alias, value, () => Alias); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetField(ref _comment, value, () => Comment); }
        }

        private bool? _IsIP;
        /// <summary>
        /// ОПФ индивидуального предпринимателя
        /// </summary>
        public bool? IsIP
        {
            get { return _IsIP; }
            set { SetField(ref _IsIP, value, () => IsIP); }
        } 
        
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Opf)
                return Id == ((Opf)obj).Id;
            return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
