using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    /// <summary>
    /// Обработка стороны
    /// </summary>
    public class SideProcessing : FormulaItemProcessing
    {
        public SideProcessing()
        {
            Enumerator = FormulaItemProcessingEnum.SideProcessing;
        }

        public int SelectedSides { get; set; }
    }
}