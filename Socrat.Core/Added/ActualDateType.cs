namespace Socrat.Core.Added
{
    /// <summary>
    /// Актуальная дата договора определяется по дате
    /// </summary>
    public enum ActualDateType
    {
        None,
        /// <summary>
        /// Ввода заказа
        /// </summary>
        Input,
        /// <summary>
        /// Производства заказа
        /// </summary>
        Work,
        /// <summary>
        /// Реализации/отгрузки/заказчика
        /// </summary>
        Customer
    }
}