using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Socrat.Core.Added
{
    public enum PoolStartEnum
    {
        [Display(Name = "Не определен")]
        None = 0,
        [Display(Name = "С новой пирамиды")]
        NewPiramid,
        [Display(Name = "С новой пачки")]
        NewStack
    }
}