namespace Socrat.MVC.PrintModels.Invoices
{
    public class InvoiceItem
    {
        #region Properties
        /// <summary>
        /// Номер по порядку
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Количество изделий
        /// </summary>
        public string Quantity { get; set; }
        /// <summary>
        /// Размер изделия
        /// </summary>
        public string ItemSize { get; set; }
        /// <summary>
        /// Общий размер
        /// </summary>
        public string TotalSize { get; set; }
        /// <summary>
        /// Цена за изделие
        /// </summary>
        public string ItemPrice { get; set; }
        /// <summary>
        /// Итого за строку счета
        /// </summary>
        public string TotalPrice { get; set; }

        #endregion

        public InvoiceItem(){}

        public InvoiceItem(int number, Core.Entities.Invoices.InvoiceItem invoiceItem)
        {

        }
    }
}
