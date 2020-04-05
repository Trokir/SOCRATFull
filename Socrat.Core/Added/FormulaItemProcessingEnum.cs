using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Socrat.Core.Added
{
    public enum FormulaItemProcessingEnum
    {
        [Display(Name ="Выбор комплектующих")]
        СomponentsProcessing = 0,
        [Display(Name = "Выбор поверхности и комплектующих")]
        SurfaseProcessing = 1,
        [Display(Name = "Выбор стороны и комплектующих")]
        SideProcessing = 2,
        [Display(Name = "Выбор стороны и величины отступа")]
        EdgeProcessing = 3
    }
}