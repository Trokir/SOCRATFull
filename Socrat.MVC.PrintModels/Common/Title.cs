using System;

namespace Socrat.MVC.PrintModels.Common
{
    /// <summary>
    /// Заголовочная часть (шапка) отчета
    /// Использован в:
    /// - Отчет "Закалка"
    /// </summary>
    public class Title : PrintModel
    {
        /// <summary>
        /// Дата отчета
        /// </summary>
        public DateTime ReportDate { get; set; }
        /// <summary>
        /// Начало отчетного периода
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// Конец отчетного периода
        /// </summary>
        public DateTime To { get; set; }
        /// <summary>
        /// Производственная площадка, по которой делается отчет
        /// </summary>
        public string DivisionName { get; set; }
        /// <summary>
        /// Предмет отчета (например, элемент или группа номенклатуры, типа "закаленное стекло")
        /// </summary>
        public string Subject { get; set; }
   
    }
}
