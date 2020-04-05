using System;

namespace Socrat.Data.Model
{
    /// <summary>
    ///     Класс, устанавливающий границы площадей по умолчанию для формирования стандартного списка наценок по площадям для
    ///     прайс-листа
    /// </summary>
    public class SquRange : Entity
    {
        public Guid? DivisionId { get; set; }

        /// <summary>
        ///     Производственная площадка
        ///     <see cref="Division" />
        /// </summary>
        public virtual Division Division { get; set; }

        /// <summary>
        ///     Порог площади
        /// </summary>
        public double Squ { get; set; }
    }
}