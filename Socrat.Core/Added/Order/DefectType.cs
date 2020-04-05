using System.ComponentModel.DataAnnotations;

namespace Socrat.Core.Added.Order
{
    /// <summary>
    /// Тип брака
    /// </summary>
    public enum DefectType
    {
        [Display(Name = "Не определено")]
        None = 0,
        [Display(Name = "Производственный")]
        Product,
        [Display(Name = "Рекламация (возврат)")]
        Reclamation
    }
}