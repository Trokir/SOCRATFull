using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public static class FormulaItemProcessingBuilder
    {
        public static FormulaItemProcessing CreateByEnum(FormulaItemProcessingEnum enumerator)
        {
            switch (enumerator)
            {
                case FormulaItemProcessingEnum.SurfaseProcessing:
                    return new SurfaseProcessing();
            }
            return null;
        }

        public static FormulaItemProcessing CreateByEnum(FormulaItemProcessingEnum enumerator, FormulaItem formulaItem, Processing processing)
        {
            switch (enumerator)
            {
                case FormulaItemProcessingEnum.SurfaseProcessing:
                    return new SurfaseProcessing
                    {
                        FormulaItem = formulaItem,
                        Processing = processing
                    };
            }
            return null;
        }

        public static FormulaItemProcessing CreateByProcessing(Processing processing, FormulaItem formulaItem)
        {
            switch (processing.ProcessingType.Enumerator)
            {
                case FormulaItemProcessingEnum.SurfaseProcessing:
                    return new SurfaseProcessing { FormulaItem = formulaItem, Processing = processing };
                case FormulaItemProcessingEnum.EdgeProcessing:
                    return new EdgeProcessing { FormulaItem = formulaItem, Processing = processing };
                case FormulaItemProcessingEnum.SideProcessing:
                    return new SideProcessing { FormulaItem = formulaItem, Processing = processing };
                case FormulaItemProcessingEnum.СomponentsProcessing:
                    return new FormulaItemProcessing { FormulaItem = formulaItem, Processing = processing };
            }
            return new FormulaItemProcessing { FormulaItem = formulaItem, Processing = processing };
        }
    }
}