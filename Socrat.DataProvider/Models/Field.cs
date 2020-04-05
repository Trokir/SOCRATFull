using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Field : Entity
    {
        public Field()
        {
            FieldValues = new HashSet<FieldValue>();
            MaterialFields = new HashSet<MaterialField>();
        }


        public string Name { get; set; }

        public bool? IsFixed { get; set; }

        public virtual ICollection<FieldValue> FieldValues { get; set; }
        public virtual ICollection<MaterialField> MaterialFields { get; set; }
    }
}