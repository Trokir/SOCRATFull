namespace Socrat.Model.Params
{
    public enum ParamAlias
    {
        NewParameter,
        // Номер заказа 
        OrderNumber,
        /// <summary>
        /// Текущий год (для сброса годовых счетчиков (например счетчик заявок))
        /// </summary>
        OrderCounterYear,
        /// <summary>
        /// Текущий год (для сброса годовых счетчиков (например счетчик счетов))
        /// </summary>
        InvoiceCounterYear,
        /// <summary>
        /// Текущее подразделение
        /// </summary>
        CurrentDivision,
        /// <summary>
        /// Граница времи изготовления, после которой дата изготовления переноситься на следующий день
        /// </summary>
        DateTransferTime,
        /// <summary>
        /// Изделие по умолчанию
        /// </summary>
        DefaultItem
    }
}