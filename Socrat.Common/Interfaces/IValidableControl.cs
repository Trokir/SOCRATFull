using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace Socrat.Common.Interfaces
{
    /// <summary>
    /// Интерфейс, представляющий собой валидируемый элемент управления
    /// </summary>
    public interface IValidableControl
    {
        /// <summary>
        /// Возвращает список валидируемых контролов в текущей имплементации интерфейса
        /// </summary>
        /// <returns></returns>
        List<BaseEdit> GetValidableControls();
    }
}
