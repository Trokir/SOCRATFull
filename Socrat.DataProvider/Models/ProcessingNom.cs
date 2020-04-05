using Socrat.Data.Model.Machines;
using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class ProcessingNom : Entity
    {
        public ProcessingNom()
        {
            PriceProcessings = new HashSet<PricePeriodProcessingNom>();
            FormulaItemProcessings = new HashSet<FormulaItemProcessing>();
        }

        public Guid ProcessingId { get; set; }
        public Guid? MachineGroupId { get; set; }
        public string Code1C { get; set; }
        public virtual Processing Processing { get; set; }
        public virtual MachineGroup MachineGroup { get; set; }

        public virtual ICollection<PricePeriodProcessingNom> PriceProcessings { get; set; }
        public virtual ICollection<FormulaItemProcessing> FormulaItemProcessings { get; set; }
    }
}