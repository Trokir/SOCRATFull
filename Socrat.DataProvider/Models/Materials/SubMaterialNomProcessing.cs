using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    /// <summary>
    ///     Операция полуфадриката
    /// </summary>
    public class SubMaterialNomProcessing : Entity
    {
        public SubMaterialNomProcessing()
        {
            Components = new HashSet<SubMaterialNomProcessingComponent>();
        }

        public int Sequence { get; set; }
        public Guid SubMaterialNomId { get; set; }
        public virtual SubMaterialNom SubMaterialNom { get; set; }
        public Guid ProcessingNomId { get; set; }
        public virtual ProcessingNom ProcessingNom { get; set; }
        public double? Distance1 { get; set; }
        public double? Distance2 { get; set; }
        public double? Distance3 { get; set; }
        public double? Distance4 { get; set; }
        public double? Distance5 { get; set; }
        public double? Distance6 { get; set; }
        public double? Distance7 { get; set; }
        public double? Distance8 { get; set; }
        public virtual ICollection<SubMaterialNomProcessingComponent> Components { get; set; }
    }
}