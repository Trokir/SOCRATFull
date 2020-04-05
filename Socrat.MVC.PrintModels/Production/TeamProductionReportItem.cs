namespace Socrat.MVC.PrintModels.Production
{
    /// <summary>
    /// Модель строки отчета, дополненная типом исполняемой операции и исполнителем
    /// </summary>
    public class TeamProductionReportItem : ProductionReportItem
    {
        /// <summary>
        /// Группа исполнителей (бригада) или отдельный исполнитель операции (например, бригада Иванова)
        /// </summary>
        public string ProducerName { get; set; }
        /// <summary>
        /// Тип операции или сама операции (Например: резка)
        /// </summary>
        public string OperationTypeName { get; set; }
    }
}
