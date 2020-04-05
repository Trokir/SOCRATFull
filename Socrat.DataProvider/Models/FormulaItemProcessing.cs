using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Socrat.Common.Enums;

namespace Socrat.Data.Model
{
    public class FormulaItemProcessing : Entity
    {
        public FormulaItemProcessing()
        {
            Components = new HashSet<ProcessingComponent>();
        }

        public Guid FormulaItemId { get; set; }
        public Guid ProcessingNomId { get; set; }
        public virtual FormulaItem FormulaItem { get; set; }
        public virtual ProcessingNom ProcessingNom { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public double? Distance1 { get; set; }
        public double? Distance2 { get; set; }
        public double? Distance3 { get; set; }
        public double? Distance4 { get; set; }
        public double? Distance5 { get; set; }
        public double? Distance6 { get; set; }
        public double? Distance7 { get; set; }
        public double? Distance8 { get; set; }
        public short? Sequence { get; set; }
        public virtual ICollection<ProcessingComponent> Components { get; set; }

        [NotMapped] public FormulaItemProcessingEnum Enumerator { get; set; }
    }
}