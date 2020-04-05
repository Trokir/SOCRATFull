using Socrat.Common.Interfaces.Planning;
using System.Collections.Generic;

namespace Socrat.Core.Entities.Planing
{
    public class AssemblyPlanPrintingWrapper
    {
        public List<SortedEntityWrapper> Entities { get; private set; }
        public AssemblyPlanPrintingWrapper(List<SortedEntityWrapper> entities)
        {
            Entities = entities;
        }
    }

    public class GlassCuttingsPrintingWrapper {}    

    public class PyramidLabelPrintingWrapper {}

    public class PrintProductionItemLabelsWrapper {}
}
   
