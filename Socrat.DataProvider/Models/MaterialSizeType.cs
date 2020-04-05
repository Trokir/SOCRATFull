using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class MaterialSizeType : Entity
    {
        public MaterialSizeType()
        {
            MaterialNoms = new HashSet<MaterialNom>();
        }
        public Guid? MaterialMarkTypeId { get; set; }
        public double Thickness { get; set; }
        public Guid? MeasureId { get; set; }
        public Guid? DefaultMaterialNomId { get; set; }
        public virtual MaterialNom DefaultMaterialNom { get; set; }
        public virtual MaterialMarkType MaterialMarkType { get; set; }
        public virtual Measure Measure { get; set; }
        public string Mark { get; set; }
        public virtual ICollection<MaterialNom> MaterialNoms { get; set; }
    }
}