using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    /// <summary>
    /// Обработка кромки
    /// </summary>
    public class EdgeProcessing : FormulaItemProcessing
    {
        public EdgeProcessing()
        {
            Enumerator = FormulaItemProcessingEnum.EdgeProcessing;
        }
    }
}