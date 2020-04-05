namespace Socrat.MVC.PrintModels.Planning
{
    /// <summary>
    /// Элемент обьема производства
    /// </summary>
    public class ProductionVolumesItem : PrintModel
    {
        /// <summary>
        /// Количество изделий элемента
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Площадь изделий элемента
        /// </summary>
        public double Square { get; set; }

        public ProductionVolumesItem(string name, int quantity, double square)
        {
            Title = name;
            Quantity = quantity;
            Square = square;
        }
    }
}
